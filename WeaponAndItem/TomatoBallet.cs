using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoBallet : MonoBehaviour
{
    //�e�̈ړ����x
    public float _bulletWeightSpeed
                ,_bulletHeightSpeed;

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
        if(_bulletHeightSpeed >= 0) 
        {
            //�c�ړ������X�Ɍ���������
            _bulletHeightSpeed -= Time.deltaTime * 0.25f;
        }

        //�e�̉��ړ�
        transform.position += transform.right * _bulletWeightSpeed * _bulletForce;

        //�e�̏c�ړ�
        transform.position += transform.up * _bulletHeightSpeed * _bulletForce;
    }
}
