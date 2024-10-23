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
        // �w�i�摜��x���W
        _startpos = transform.position.x;

        // �w�i�摜��x�������̕�
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        // �����X�N���[���Ɏg�p����p�����[�^�[
        float temp = (_camera.transform.position.x * (1 - _scrollSpeed));
        //�w�i�̎������ʂɎg�p����p�����[�^�[
        float dist = (_camera.transform.position.x * _scrollSpeed);

        // �������ʂ�^���鏈��
        //�w�i�摜��x���W��dist�̕��ړ�������
        transform.position = new Vector3(_startpos + dist, transform.position.y, transform.position.z);

        //��ʊO�ɍs������w�i�摜���ړ�������
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
