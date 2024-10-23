using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaBullet : MonoBehaviour
{
    //ã‚ª‚é’e‚Ì‘¬“x
    public float _bulletUpperSpeed;

    //’e‚ÌˆÚ“®‘¬“x
    public float _bulletSpeed;

    //’e‚ÌŒü‚«
    private int _bulletForce;

    void Start()
    {
        //’e‚ÌˆÚ“®
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

        //’e‚ÌˆÚ“®
        transform.position += transform.right * _bulletSpeed * _bulletForce;

        //’e‚ÌãˆÚ“®
        rigidBody2D.AddForce(this.transform.up * _bulletUpperSpeed);
    }
}
