using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //スクリプト
    public SoundManager _soundManager;

    //アニメーション
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
        //左クリック
        if(Input.GetMouseButtonDown(0)) 
        { 
            //アニメーション
            _animator.SetBool("GameStart", true);

            _soundManager.StartDash();
        }

        //アニメーションが発動したら
        if(_animator.GetBool("GameStart") == true)
        {
            //時間を測る
            _timeSceneManagement += Time.deltaTime;
        }

        //一定時間過ぎたら
        if(_timeSceneManagement >= 5f) 
        {
            //ゲームシーンに移行
            SceneManager.LoadScene("SampleScene");
        }
    }
}
