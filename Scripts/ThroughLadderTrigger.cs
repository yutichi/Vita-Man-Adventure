using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughLadderTrigger : MonoBehaviour
{
    public static bool _throughOn;

    //�͂����p��Collider
    [SerializeField]
    private BoxCollider2D _ladderCollider2D;

    void Start()
    {
        _ladderCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //���Ⴊ��Ă�����
        if(Input.GetKey(KeyCode.LeftShift))
        {
            //Trigger�ɂ���
            _ladderCollider2D.isTrigger = true;
        }
        //����ȊO�̏��
        else
        {
            //Collision�ɂ���
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
