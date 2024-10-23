using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //�X�N���v�g
    public SoundManager _soundManager;

    //�A�j���[�V����
    private Animator _animator;

    private float _timeSceneManagement;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        Time.timeScale = 1.35f;
        _timeSceneManagement = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //���N���b�N
        if(Input.GetMouseButtonDown(0)) 
        { 
            //�A�j���[�V����
            _animator.SetBool("GameStart", true);

            _soundManager.StartDash();
        }

        //�A�j���[�V����������������
        if(_animator.GetBool("GameStart") == true)
        {
            //���Ԃ𑪂�
            _timeSceneManagement += Time.deltaTime;
        }

        //��莞�ԉ߂�����
        if(_timeSceneManagement >= 5f) 
        {
            //�Q�[���V�[���Ɉڍs
            SceneManager.LoadScene("SampleScene");
        }
    }
}
