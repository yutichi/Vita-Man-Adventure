using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyfishScripts : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    //速度
    public float _speed;

    //イクラ爆弾
    [SerializeField]
    private GameObject[] _samonEgg;

    //攻撃用タイマー
    private float _attackTimmer;

    //攻撃インターバルの最大時間、最小時間
    public float _maxInterval
                ,_minInterval;

    //初期地点の座標
    private Transform _startPos;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        //最初の攻撃インターバルを決定
        _attackTimmer = Random.Range(_minInterval, _maxInterval);

        //初期地点の座標を取得
        _startPos = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_startPos == !GetComponent<Renderer>().isVisible)
        {
            //画面外に行ったら初期地点に戻る
            gameObject.transform.position = _startPos.position;
        }

        if (!GetComponent<Renderer>().isVisible) return;

        //攻撃のクールタイムを減らす
        _attackTimmer -= Time.deltaTime;

        if(_attackTimmer < 0f)
        {
            Instantiate(_samonEgg[0], transform.position, Quaternion.identity);

            //次の攻撃インターバルを決定
            _attackTimmer = Random.Range(_minInterval, _maxInterval);
        }

        //移動
        transform.position -= transform.right * _speed * Time.deltaTime;
    }
}
