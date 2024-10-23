using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerItemUI : MonoBehaviour
{
    //スクリプト
    public ShadowCaster2D _shadowCaster2D;
    public SoundManager _soundManager;

    //CinemachineカメラOffset
    [SerializeField]
    private CinemachineCameraOffset _cinemachineCameraOffset;

    //カメラの位置
    [SerializeField]
    private Transform _cinemachineCamera;

    //ズームする値
    [SerializeField]
    private float _zoomViewMax
                 ,_zoomViewMin;
    private float _zoomTimmer = 0f;

    //ズームするかどうかのトリガー
    private bool _zoomTrigger;

    //フェードさせるUIグループ
    [SerializeField]
    private CanvasGroup _canvasGroupUI;

    //フェード時間
    public float _duration;

    //各武器の使用中ランプ
    [SerializeField]
    private GameObject _carrotLamp
                      ,_tomatoLamp
                      ,_bananaLamp
                      ,_watermelonLamp;

    // Start is called before the first frame update
    void Start()
    {
        _zoomTrigger = false;
        _canvasGroupUI.alpha = 0f;
        _shadowCaster2D.enabled = false;

        _carrotLamp.SetActive(true);
        _tomatoLamp.SetActive(false);
        _bananaLamp.SetActive(false);
        _watermelonLamp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //カメラのズームイン、アウト
        _cinemachineCameraOffset.m_Offset = transform.localToWorldMatrix * new Vector3(0, 0, _zoomTimmer);

        //Escを押したらアイテム画面の開閉ができる
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            _soundManager.OpenUISE();

            if (!_zoomTrigger)
            {
                _zoomTrigger = true;
            }
            else
            {
                _zoomTrigger = false;
            }
        }

        //true:アイテム表示
        if (_zoomTrigger == true && _zoomTimmer >= _zoomViewMin)
        {
            //カメラのズームアウト
            _zoomTimmer -= Time.deltaTime * 2;

            //UIのフェードイン
            _canvasGroupUI.alpha += Time.deltaTime / _duration;

            //UIのShadowCaster2Dをオン
            _shadowCaster2D.enabled = true;
        }
        //false:アイテム非表示
        else if(_zoomTrigger == false && _zoomTimmer <= _zoomViewMax) 
        {
            //カメラのズームイン
            _zoomTimmer += Time.deltaTime * 2;

            //UIのフェードアウト
            _canvasGroupUI.alpha -= Time.deltaTime / _duration;

            //UIのShadowCaster2Dをオフ
            _shadowCaster2D.enabled = false;
        }
    }

    //武器チェンジボタン
    public void ChangeWeapon(int weaponNum)
    {
        Debug.Log(weaponNum + "WeaponButton");

        //全てのランプを非表示
        _carrotLamp.SetActive(false);
        _tomatoLamp.SetActive(false);
        _bananaLamp.SetActive(false);
        _watermelonLamp.SetActive(false);

        //指定した武器切り替え
        WeaponScripts._equipmentWeapon = weaponNum;

        //指定した武器のランプを表示
        switch(weaponNum)
        {
            case 0:
                _watermelonLamp.SetActive(true);
                break;
            case 1:
                _carrotLamp.SetActive(true);
                break;
            case 2:
                _tomatoLamp.SetActive(true);
                break;
            case 3:
                _bananaLamp.SetActive(true);
                break;
            default:
                //エラーログ
                Debug.Log("DefaultError");
                break;
        }

        //UIを非表示
        _zoomTrigger = false;

        _soundManager.ButtonSE();
    }
}
