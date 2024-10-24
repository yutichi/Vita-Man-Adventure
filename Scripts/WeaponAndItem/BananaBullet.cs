using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaBullet : MonoBehaviour
{
    //上がる弾の速度
    public float _bulletUpperSpeed;

    //弾の移動速度
    public float _bulletSpeed;

    //弾の向き
    private int _bulletForce;

    void Start()
    {
        //弾の移動
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

        //弾の移動
        transform.position += transform.right * _bulletSpeed * _bulletForce;

        //弾の上移動
        rigidBody2D.AddForce(this.transform.up * _bulletUpperSpeed);
    }
}
