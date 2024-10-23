using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScripts : MonoBehaviour
{
    private float _length
                 ,_startpos;

    [SerializeField]
    private GameObject _camera;

    [SerializeField]
    public float _scrollSpeed;

    void Start()
    {
        // 背景画像のx座標
        _startpos = transform.position.x;

        // 背景画像のx軸方向の幅
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        // 無限スクロールに使用するパラメーター
        float temp = (_camera.transform.position.x * (1 - _scrollSpeed));
        //背景の視差効果に使用するパラメーター
        float dist = (_camera.transform.position.x * _scrollSpeed);

        // 視差効果を与える処理
        //背景画像のx座標をdistの分移動させる
        transform.position = new Vector3(_startpos + dist, transform.position.y, transform.position.z);

        //画面外に行ったら背景画像を移動させる
        if (temp > _startpos + _length)
        {
            _startpos += _length;
        }
        else if (temp < _startpos - _length)
        { 
            _startpos -= _length; 
        }
    }
}
