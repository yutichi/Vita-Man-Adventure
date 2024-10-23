using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource _audioSurce;

    [SerializeField]
    public AudioClip _startDashSE
                    ,_jumpSE
                    ,_weaponSE
                    ,_downEnemySE
                    ,_downPlayerSE
                    ,_buttonSE
                    ,_openUISE;       

    // Start is called before the first frame update
    void Start()
    {
        _audioSurce = GetComponent<AudioSource>();
    }

    public void StartDash()
    {
        _audioSurce.PlayOneShot(_startDashSE);
    }

    public void JumpSE()
    {
        _audioSurce.PlayOneShot(_jumpSE);
    }

    public void WeaaponSE()
    {
        _audioSurce.PlayOneShot(_weaponSE);
    }

    public void DownEnemySE()
    {
        _audioSurce.PlayOneShot(_downEnemySE);
    }

    public void DownPlayerSE()
    {
        _audioSurce.PlayOneShot(_downPlayerSE);
    }

    public void ButtonSE()
    {
        _audioSurce.PlayOneShot(_buttonSE);
    }

    public void OpenUISE()
    {
        _audioSurce.PlayOneShot(_openUISE);
    }
}
