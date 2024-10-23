using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private SpriteRenderer _spriteRenderer;

    //�X�N���v�g
    public SoundManager _soundManager;

    //�ړ����x
    public float _speed = 1.5f;

    //�W�����v��
    public float _jumpPower = 7.5f;

    //�W�����v�{�^���������Ă��邩�ǂ����̔���
    private bool _jumpOn
                ,_jumpOff;

    //�W�����v���̍ۂ̍���
    private float _jumpY;

    //�W�����v���̍�������
    [SerializeField]
    private float _jumpLimit = 2.0f;

    //�n�ʂɂ��邩�ǂ����̔���
    private bool _groundOn;

    //�W�����v�ł��邩�ǂ����̔���
    private bool _jumpTrigger;

    //�W�����v�������\�Ȏ���
    public float _jumpTimmer = 0.85f;

    //���Ⴊ�񂾍ۂɓ����蔻���ύX����Collider2D
    [SerializeField]
    private BoxCollider2D _boxCollider2D;

    //�V��ɂԂ��������ǂ����̔���
    private bool _roofTrigger;

    //�͂����ɐG��Ă��邩�ǂ����̔���
    private bool _ladderTrigger;

    //�A�j���[�V����
    private Animator _animator;

    //�v���C���[�̌�����ς���g���K�[
    public static bool _directionTrigger;

    //���蔲�����ɐG��Ă��邩�ǂ���
    private bool _throughOn;

    //�Q�[���I�[�o�[�p�̃^�C�}�[
    private float _gameOverTimmer;

    //�R�[���̎擾��
    private int _coonCount = 0;

    //�R�[���̎擾���e�L�X�g
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
        //�Q�[���I�[�o�[�A�j���[�V�����̊J�n���́A�v���C���[�������y���W�ȉ��̎�
        if (_animator.GetBool("GameOver") == true || this.transform.position.y <= -5.5)
        {
            _gameOverTimmer += Time.deltaTime;

            _soundManager.DownPlayerSE();

            if(_gameOverTimmer > 3.5f) 
            {
                //�Q�[���I�[�o�[�V�[���Ɉڍs����
                SceneManager.LoadScene("GameOver");
            }

            return;
        }

        //�R�[���̎擾���X�V
        _coonCountText.text = "�~" + _coonCount;

        //���ړ�
        if (Input.GetKey(KeyCode.A))
        {
            //�ړ�
            transform.position -= transform.right * _speed * Time.deltaTime;

            //�A�j���[�V����
            _animator.SetBool("Running", true);
            _animator.SetBool("Crouching", false);

            //������ύX
            _directionTrigger = false;
            _spriteRenderer.flipX = true;

            //��q�ɏ�肷�蔲���鏰�ɐG��Ă��鎞
            if(_ladderTrigger == true 
            && ThroughLadderTrigger._throughOn == true)
            {
                //��q����肫��
                transform.position += transform.up * 1f;

                //��q��Ԃ�����
                _ladderTrigger = false;
            }
            //��q�ɏ���Ă鎞
            else if (_ladderTrigger == true)
            {
                //���͂��ꂽ���q����~���
                _ladderTrigger = false;
            }
        }
        //�E�ړ�
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
        //���E�ړ����Ă��Ȃ���
        else 
        {
            //�A�j���[�V��������������
            _animator.SetBool("Running", false);
        }

        //�W�����v
        Jump();

        if(Input.GetKey(KeyCode.Space)
            && _jumpTrigger == true
            && _jumpTimmer > 0f)
        {
            //�����Ă���Ƃ�
            _jumpOn = true;

            _groundOn = false;

            //���������̎��Ԍ���
            _jumpTimmer -= Time.deltaTime;

            if(_ladderTrigger == true)
            {
                _ladderTrigger = false;
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space) || _jumpTimmer <= 0f)
        {
            //�����Ă���Ƃ�
            _jumpOn = false;

            _jumpTrigger = false;
        }
        //SE�p
        if(Input.GetKeyDown(KeyCode.Space) && _jumpTrigger)
        {
            _soundManager.JumpSE();
        }

        //���Ⴊ��
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //�����蔻�������������
            _boxCollider2D.size = new Vector2(0.4f, 0.65f);

            //�ړ����x��������
            _speed = 0.5f;

            //�A�j���[�V����
            _animator.SetBool("Crouching", true);
            _animator.SetBool("Running", false);
        }
        else
        {
            //���̓����蔻��ɖ߂�
            _boxCollider2D.size = new Vector2(0.4f, 1.03f);

            _speed = 1.75f;

            _animator.SetBool("Crouching", false);
        }

        //�͂����ړ�
        if (_ladderTrigger && _groundOn)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.up * _speed * Time.deltaTime;

                //�d�͂𖳎�����
                _rigidBody2D.gravityScale = 0f;

                //�A�j���[�V����
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
            //�d�͂����ɖ߂�
            _rigidBody2D.gravityScale = 1.5f;

            _animator.SetBool("Ladder", false);
        }
    }

    //�W�����v���鏈��
    void Jump()
    {
        //�n�ʂɂ���Ƃ�
        if (_groundOn)
        {
            //��юn�߂��L�^
            _jumpY = transform.position.y - _jumpLimit * 1.85f;
        }

        if (_jumpTrigger)
        {
            if (_jumpOn && _jumpY + _jumpLimit < transform.position.y && _roofTrigger == false)
            {
                Debug.Log("Jump");

                //�W�����v
                _rigidBody2D.velocity = transform.up * _jumpPower * 2f;
            }
            else if (_jumpOff || _jumpY + _jumpLimit < transform.position.y
                              || _roofTrigger == true)
            {
                //����
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
            //�n�ʂɂ���Ƃ�true�ɂ���
            _groundOn = true;

            _jumpTimmer = 0.85f;
        }

        //�S�[���ɐG�ꂽ��
        if(collision.gameObject.tag == "Goal")
        {
            //�S�[���V�[���Ɉڍs����
            SceneManager.LoadScene("ClearScene");
        }

        //�G�ɐG�ꂽ��
        if(collision.gameObject.tag == "Enemy")
        {
            //�A�j���[�V����
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

        //�R�[���ɐG�ꂽ��
        if (other.gameObject.tag == "CoonCoin")
        {
            //�R�[���̃J�E���g������
            _coonCount++;

            //�j�󂷂�
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
