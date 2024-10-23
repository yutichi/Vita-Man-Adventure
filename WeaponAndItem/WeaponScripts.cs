using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScripts : MonoBehaviour
{
    //�X�N���v�g
    public SoundManager _soundManager;

    //�v���C���[�̒e
    [SerializeField]
    private GameObject[] _playerBullet;

    //���ˌ�
    [SerializeField]
    private Transform _nozzle;

    //�������Ă���e
    public static int _equipmentWeapon = 1;

    //�e����c�e��
    public static int _carrotStock
                     ,_tomatoStock
                     ,_bananaStock
                     ,_watermelonStock;

    //����̃N�[���^�C��
    private float _coolDown;

    // Start is called before the first frame update
    void Start()
    {
        _equipmentWeapon = 1;
        _coolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //�N�[���^�C���̌v�Z��
        var coolDownTime = _equipmentWeapon * _equipmentWeapon + 1;

        if (_coolDown > 0)
        {
            //�N�[���^�C������
            _coolDown -= Time.deltaTime;
        }

        //�e�𔭎�
        if(Input.GetMouseButtonDown(1) && _coolDown <= 0) 
        {
            //�e����
            GameObject bullet = Instantiate(_playerBullet[_equipmentWeapon]
                                ,_nozzle.position, Quaternion.identity);

            //�N�[���^�C�����Z�b�g
            _coolDown = coolDownTime;

            _soundManager.WeaaponSE();
        }
    }

    public void ChangeWeapon()
    {

    }
}
