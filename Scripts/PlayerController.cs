using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private SpriteRenderer _spriteRenderer;

    //スクリプト
    public SoundManager _soundManager;

    //移動速度
    public float _speed = 1.5f;

    //ジャンプ力
    public float _jumpPower = 7.5f;

    //ジャンプボタンを押しているかどうかの判定
    private bool _jumpOn
                ,_jumpOff;

    //ジャンプ時の際の高さ
    private float _jumpY;

    //ジャンプ時の高さ制限
    [SerializeField]
    private float _jumpLimit = 2.0f;

    //地面にいるかどうかの判定
    private bool _groundOn;

    //ジャンプできるかどうかの判定
    private bool _jumpTrigger;

    //ジャンプ長押し可能な時間
    public float _jumpTimmer = 0.85f;

    //しゃがんだ際に当たり判定を変更するCollider2D
    [SerializeField]
    private BoxCollider2D _boxCollider2D;

    //天井にぶつかったかどうかの判定
    private bool _roofTrigger;

    //はしごに触れているかどうかの判定
    private bool _ladderTrigger;

    //アニメーション
    private Animator _animator;

    //プレイヤーの向きを変えるトリガー
    public static bool _directionTrigger;

    //すり抜け床に触れているかどうか
    private bool _throughOn;

    //ゲームオーバー用のタイマー
    private float _gameOverTimmer;

    //コーンの取得数
    private int _coonCount = 0;

    //コーンの取得数テキスト
    [SerializeField]
    private TextMeshProUGUI _coonCountText;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

        _directionTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {       
        //ゲームオーバーアニメーションの開始又は、プレイヤーが特定のy座標以下の時
        if (_animator.GetBool("GameOver") == true || this.transform.position.y <= -5.5)
        {
            _gameOverTimmer += Time.deltaTime;

            _soundManager.DownPlayerSE();

            if(_gameOverTimmer > 3.5f) 
            {
                //ゲームオーバーシーンに移行する
                SceneManager.LoadScene("GameOver");
            }

            return;
        }

        //コーンの取得数更新
        _coonCountText.text = "×" + _coonCount;

        //左移動
        if (Input.GetKey(KeyCode.A))
        {
            //移動
            transform.position -= transform.right * _speed * Time.deltaTime;

            //アニメーション
            _animator.SetBool("Running", true);
            _animator.SetBool("Crouching", false);

            //向きを変更
            _directionTrigger = false;
            _spriteRenderer.flipX = true;

            //梯子に上りすり抜ける床に触れている時
            if(_ladderTrigger == true 
            && ThroughLadderTrigger._throughOn == true)
            {
                //梯子を上りきる
                transform.position += transform.up * 1f;

                //梯子状態を解除
                _ladderTrigger = false;
            }
            //梯子に上ってる時
            else if (_ladderTrigger == true)
            {
                //入力されたら梯子から降りる
                _ladderTrigger = false;
            }
        }
        //右移動
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * _speed * Time.deltaTime;

            _animator.SetBool("Running", true);

            _directionTrigger = true;
            _spriteRenderer.flipX = false;

            if (_ladderTrigger == true 
             && ThroughLadderTrigger._throughOn == true)
            {
                transform.position += transform.up * 1f;

                _ladderTrigger = false;
            }
            else if (_ladderTrigger == true)
            {
                _ladderTrigger = false;
            }
        }
        //左右移動していない時
        else 
        {
            //アニメーションを解除する
            _animator.SetBool("Running", false);
        }

        //ジャンプ
        Jump();

        if(Input.GetKey(KeyCode.Space)
            && _jumpTrigger == true
            && _jumpTimmer > 0f)
        {
            //押しているとき
            _jumpOn = true;

            _groundOn = false;

            //長押し中の時間減少
            _jumpTimmer -= Time.deltaTime;

            if(_ladderTrigger == true)
            {
                _ladderTrigger = false;
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space) || _jumpTimmer <= 0f)
        {
            //離しているとき
            _jumpOn = false;

            _jumpTrigger = false;
        }
        //SE用
        if(Input.GetKeyDown(KeyCode.Space) && _jumpTrigger)
        {
            _soundManager.JumpSE();
        }

        //しゃがみ
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //当たり判定を小さくする
            _boxCollider2D.size = new Vector2(0.4f, 0.65f);

            //移動速度を下げる
            _speed = 0.5f;

            //アニメーション
            _animator.SetBool("Crouching", true);
            _animator.SetBool("Running", false);
        }
        else
        {
            //元の当たり判定に戻す
            _boxCollider2D.size = new Vector2(0.4f, 1.03f);

            _speed = 1.75f;

            _animator.SetBool("Crouching", false);
        }

        //はしご移動
        if (_ladderTrigger && _groundOn)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.up * _speed * Time.deltaTime;

                //重力を無視する
                _rigidBody2D.gravityScale = 0f;

                //アニメーション
                _animator.SetBool("Ladder", true);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.up * _speed * Time.deltaTime;

                _rigidBody2D.gravityScale = 0f;

                _animator.SetBool("Ladder", true);
            }
        }
        else
        {
            //重力が元に戻る
            _rigidBody2D.gravityScale = 1.5f;

            _animator.SetBool("Ladder", false);
        }
    }

    //ジャンプする処理
    void Jump()
    {
        //地面にいるとき
        if (_groundOn)
        {
            //飛び始めを記録
            _jumpY = transform.position.y - _jumpLimit * 1.85f;
        }

        if (_jumpTrigger)
        {
            if (_jumpOn && _jumpY + _jumpLimit < transform.position.y && _roofTrigger == false)
            {
                Debug.Log("Jump");

                //ジャンプ
                _rigidBody2D.velocity = transform.up * _jumpPower * 2f;
            }
            else if (_jumpOff || _jumpY + _jumpLimit < transform.position.y
                              || _roofTrigger == true)
            {
                //落下
                //_rigidBody2D.velocity = -transform.up * _jumpPower * 0.05f;
                _rigidBody2D.gravityScale = 1.5f;
                _jumpOn = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" 
        || collision.gameObject.tag == "Through")
        {
            //地面にいるときtrueにする
            _groundOn = true;

            _jumpTimmer = 0.85f;
        }

        //ゴールに触れた時
        if(collision.gameObject.tag == "Goal")
        {
            //ゴールシーンに移行する
            SceneManager.LoadScene("ClearScene");
        }

        //敵に触れた時
        if(collision.gameObject.tag == "Enemy")
        {
            //アニメーション
            _animator.SetBool("GameOver", true);
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" 
         || collision.gameObject.tag == "Through")
        {
            _jumpTrigger = true;
            _roofTrigger = false;

            _groundOn = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            _roofTrigger = true;
        }

        if(other.gameObject.tag == "Enemy")
        {
            _animator.SetBool("GameOver", true);
        }

        //コーンに触れた時
        if (other.gameObject.tag == "CoonCoin")
        {
            //コーンのカウント数増加
            _coonCount++;

            //破壊する
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            _ladderTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ladder")
        {
            _ladderTrigger = false;
        }
    }
}
