using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerItemUI : MonoBehaviour
{
    //�X�N���v�g
    public ShadowCaster2D _shadowCaster2D;
    public SoundManager _soundManager;

    //Cinemachine�J����Offset
    [SerializeField]
    private CinemachineCameraOffset _cinemachineCameraOffset;

    //�J�����̈ʒu
    [SerializeField]
    private Transform _cinemachineCamera;

    //�Y�[������l
    [SerializeField]
    private float _zoomViewMax
                 ,_zoomViewMin;
    private float _zoomTimmer = 0f;

    //�Y�[�����邩�ǂ����̃g���K�[
    private bool _zoomTrigger;

    //�t�F�[�h������UI�O���[�v
    [SerializeField]
    private CanvasGroup _canvasGroupUI;

    //�t�F�[�h����
    public float _duration;

    //�e����̎g�p�������v
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
        //�J�����̃Y�[���C���A�A�E�g
        _cinemachineCameraOffset.m_Offset = transform.localToWorldMatrix * new Vector3(0, 0, _zoomTimmer);

        //Esc����������A�C�e����ʂ̊J���ł���
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

        //true:�A�C�e���\��
        if (_zoomTrigger == true && _zoomTimmer >= _zoomViewMin)
        {
            //�J�����̃Y�[���A�E�g
            _zoomTimmer -= Time.deltaTime * 2;

            //UI�̃t�F�[�h�C��
            _canvasGroupUI.alpha += Time.deltaTime / _duration;

            //UI��ShadowCaster2D���I��
            _shadowCaster2D.enabled = true;
        }
        //false:�A�C�e����\��
        else if(_zoomTrigger == false && _zoomTimmer <= _zoomViewMax) 
        {
            //�J�����̃Y�[���C��
            _zoomTimmer += Time.deltaTime * 2;

            //UI�̃t�F�[�h�A�E�g
            _canvasGroupUI.alpha -= Time.deltaTime / _duration;

            //UI��ShadowCaster2D���I�t
            _shadowCaster2D.enabled = false;
        }
    }

    //����`�F���W�{�^��
    public void ChangeWeapon(int weaponNum)
    {
        Debug.Log(weaponNum + "WeaponButton");

        //�S�Ẵ����v���\��
        _carrotLamp.SetActive(false);
        _tomatoLamp.SetActive(false);
        _bananaLamp.SetActive(false);
        _watermelonLamp.SetActive(false);

        //�w�肵������؂�ւ�
        WeaponScripts._equipmentWeapon = weaponNum;

        //�w�肵������̃����v��\��
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
                //�G���[���O
                Debug.Log("DefaultError");
                break;
        }

        //UI���\��
        _zoomTrigger = false;

        _soundManager.ButtonSE();
    }
}
