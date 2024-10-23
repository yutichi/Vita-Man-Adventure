using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinanagoScripts : MonoBehaviour
{
    //出現時のクールタイム
    public float _coolDown;

    //出現時用のタイマー
    private float _timmer;

    //アニメーション再生切り替え
    private bool _changePlayback;

    //アニメーション
    private Animator _animator;

    private BoxCollider2D _boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

        _animator.SetFloat(("PlayBack"), 0f);

        _changePlayback = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible) return;

        _timmer += Time.deltaTime;

        if (_timmer > _coolDown) 
        { 
            //アニメーション再生切り替え
            _changePlayback = !_changePlayback;

            _timmer = 0;
        }

        //アニメーション
        if (_changePlayback == true)
        {
            //アニメーションを逆再生
            _animator.SetFloat(("PlayBack"), -1f);

            //タグを変更、敵判定無し
            this.tag = "Untagged";
        }
        if (_changePlayback == false)
        {
            //アニメーションを再生
            _animator.SetFloat(("PlayBack"), 1f);

            //タグを変更、敵判定有り
            this.tag = "Enemy";
        }
    }
}
