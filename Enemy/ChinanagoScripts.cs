using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinanagoScripts : MonoBehaviour
{
    //�o�����̃N�[���^�C��
    public float _coolDown;

    //�o�����p�̃^�C�}�[
    private float _timmer;

    //�A�j���[�V�����Đ��؂�ւ�
    private bool _changePlayback;

    //�A�j���[�V����
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
            //�A�j���[�V�����Đ��؂�ւ�
            _changePlayback = !_changePlayback;

            _timmer = 0;
        }

        //�A�j���[�V����
        if (_changePlayback == true)
        {
            //�A�j���[�V�������t�Đ�
            _animator.SetFloat(("PlayBack"), -1f);

            //�^�O��ύX�A�G���薳��
            this.tag = "Untagged";
        }
        if (_changePlayback == false)
        {
            //�A�j���[�V�������Đ�
            _animator.SetFloat(("PlayBack"), 1f);

            //�^�O��ύX�A�G����L��
            this.tag = "Enemy";
        }
    }
}
