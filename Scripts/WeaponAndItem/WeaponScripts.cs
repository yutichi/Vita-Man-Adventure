using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScripts : MonoBehaviour
{
    //スクリプト
    public SoundManager _soundManager;

    //プレイヤーの弾
    [SerializeField]
    private GameObject[] _playerBullet;

    //発射口
    [SerializeField]
    private Transform _nozzle;

    //装備している弾
    public static int _equipmentWeapon = 1;

    //各武器残弾数
    public static int _carrotStock
                     ,_tomatoStock
                     ,_bananaStock
                     ,_watermelonStock;

    //武器のクールタイム
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
        //クールタイムの計算式
        var coolDownTime = _equipmentWeapon * _equipmentWeapon + 1;

        if (_coolDown > 0)
        {
            //クールタイム減少
            _coolDown -= Time.deltaTime;
        }

        //弾を発射
        if(Input.GetMouseButtonDown(1) && _coolDown <= 0) 
        {
            //弾生成
            GameObject bullet = Instantiate(_playerBullet[_equipmentWeapon]
                                ,_nozzle.position, Quaternion.identity);

            //クールタイムリセット
            _coolDown = coolDownTime;

            _soundManager.WeaaponSE();
        }
    }

    public void ChangeWeapon()
    {

    }
}
