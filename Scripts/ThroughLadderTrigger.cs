using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughLadderTrigger : MonoBehaviour
{
    public static bool _throughOn;

    //はしご用のCollider
    [SerializeField]
    private BoxCollider2D _ladderCollider2D;

    void Start()
    {
        _ladderCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //しゃがんていたら
        if(Input.GetKey(KeyCode.LeftShift))
        {
            //Triggerにする
            _ladderCollider2D.isTrigger = true;
        }
        //それ以外の状態
        else
        {
            //Collisionにする
            _ladderCollider2D.isTrigger = false;
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Through")
        {
            _throughOn = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Through")
        {
            _throughOn = false;
        }
    }
}
