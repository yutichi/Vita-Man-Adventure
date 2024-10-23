using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotBullet : MonoBehaviour
{
    //�e�̑��x
    [SerializeField]
    private float _bulletSpeed;

    //�e�̌���
    private int _bulletForce;

    void Start()
    {
        //�e�̈ړ�
        if (PlayerController._directionTrigger == true)
        {
            _bulletForce = 1;
        }
        else if (PlayerController._directionTrigger == false)
        {
            _bulletForce = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();

        //�e�̈ړ�
        rigidBody2D.AddForce(this.transform.right * _bulletSpeed * _bulletForce);
    }
}
