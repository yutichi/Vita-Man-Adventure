using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoBallet : MonoBehaviour
{
    //’e‚ÌˆÚ“®‘¬“x
    public float _bulletWeightSpeed
                ,_bulletHeightSpeed;

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
        if(_bulletHeightSpeed >= 0) 
        {
            //cˆÚ“®‚ğ™X‚ÉŒ¸­‚³‚¹‚é
            _bulletHeightSpeed -= Time.deltaTime * 0.25f;
        }

        //’e‚Ì‰¡ˆÚ“®
        transform.position += transform.right * _bulletWeightSpeed * _bulletForce;

        //’e‚ÌcˆÚ“®
        transform.position += transform.up * _bulletHeightSpeed * _bulletForce;
    }
}
