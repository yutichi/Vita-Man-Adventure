using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyfishScripts : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    //���x
    public float _speed;

    //�C�N�����e
    [SerializeField]
    private GameObject[] _samonEgg;

    //�U���p�^�C�}�[
    private float _attackTimmer;

    //�U���C���^�[�o���̍ő厞�ԁA�ŏ�����
    public float _maxInterval
                ,_minInterval;

    //�����n�_�̍��W
    private Transform _startPos;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        //�ŏ��̍U���C���^�[�o��������
        _attackTimmer = Random.Range(_minInterval, _maxInterval);

        //�����n�_�̍��W���擾
        _startPos = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_startPos == !GetComponent<Renderer>().isVisible)
        {
            //��ʊO�ɍs�����珉���n�_�ɖ߂�
            gameObject.transform.position = _startPos.position;
        }

        if (!GetComponent<Renderer>().isVisible) return;

        //�U���̃N�[���^�C�������炷
        _attackTimmer -= Time.deltaTime;

        if(_attackTimmer < 0f)
        {
            Instantiate(_samonEgg[0], transform.position, Quaternion.identity);

            //���̍U���C���^�[�o��������
            _attackTimmer = Random.Range(_minInterval, _maxInterval);
        }

        //�ړ�
        transform.position -= transform.right * _speed * Time.deltaTime;
    }
}
