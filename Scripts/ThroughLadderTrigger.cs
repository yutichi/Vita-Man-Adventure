using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughLadderTrigger : MonoBehaviour
{
    public static bool _throughOn;

    //ÇÕÇµÇ≤ópÇÃCollider
    [SerializeField]
    private BoxCollider2D _ladderCollider2D;

    void Start()
    {
        _ladderCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //ÇµÇ·Ç™ÇÒÇƒÇ¢ÇΩÇÁ
        if(Input.GetKey(KeyCode.LeftShift))
        {
            //TriggerÇ…Ç∑ÇÈ
            _ladderCollider2D.isTrigger = true;
        }
        //ÇªÇÍà»äOÇÃèÛë‘
        else
        {
            //CollisionÇ…Ç∑ÇÈ
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
