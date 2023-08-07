using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SFXManager : MonoBehaviour
{
    [Header("Laser SFX")]
    [SerializeField] AudioSource _audioSource;
    [Header("Bomb SFX")]
    [SerializeField] AudioSource _audioSource2;
    [Header("Rock Boom 1 SFX")]
    [SerializeField] AudioSource _rockBoomAudioSource;
    [Header("Rock Boom 2 SFX")]
    [SerializeField] AudioSource _rockBoomAudioSource2;
    [Header("Ship Death SFX")]
    [SerializeField] AudioSource _shipDeathAudioSource;
    [SerializeField] AudioClip _alert_SFX, _bomb_SFX, _comm_In_SFX, _comm_Out_SFX, _laser_SFX, _rock_Boom_SFX, _ship_Death_SFX;

    public UnityEvent _bombFXStart;
    public UnityEvent _bombFXMid;
    public UnityEvent _bombFXEnd;

    private bool _rockBoom1, _rockBoom2 = true;

    private void Awake()
    {
        _audioSource.volume = 0.2f;
        _audioSource2.volume = 1;
        _rockBoomAudioSource.volume = .4f;
        _rockBoomAudioSource2.volume = .4f;
    }
    public void Alert_SFX()
    {
        
    }

    public void Bomb_SFX()
    {
        StartCoroutine(BombTimer(4));
        _audioSource2.clip = _bomb_SFX;
        _audioSource2.Play();
    }
    public void Comm_In_SFX()
    {
       
    }
    public void Comm_Out_SFX()
    {
        
    }
    public void Laser_SFX()
    {
        float _laserPitch = Random.Range(.8f, 1f);
        _audioSource.pitch = _laserPitch;
        _audioSource.clip = _laser_SFX;
        _audioSource.Play();
    }
    public void Rock_Boom_SFX()
    {
        if(_rockBoom1 == false && _rockBoom2 == true)
        {
            RockBoomSFX1();
            _rockBoom1 = true;
            _rockBoom2 = false;
        }
        else if (_rockBoom1 == true && _rockBoom2 == false)
        {
            RockBoomSFX2();
            _rockBoom1 = false;
            _rockBoom2 = true;
        }
    }
    public void Ship_Death_SFX()
    {
        _shipDeathAudioSource.clip = _ship_Death_SFX;
        _shipDeathAudioSource.Play();

        _rockBoomAudioSource.pitch = 0.5f;
        _rockBoomAudioSource.clip = _rock_Boom_SFX;
        _rockBoomAudioSource.Play();
    }
    private void AudioLevelEventStart()
    {
        _audioSource.volume = 0;
        _rockBoomAudioSource.volume = 0;
        _rockBoomAudioSource2.volume = 0;
       
    }
    private void AudioLevelEventEnd()
    {
        _audioSource.volume = 0.2f;
        _rockBoomAudioSource.volume = .4f;
        _rockBoomAudioSource2.volume = .4f;
    }
    private void RockBoomSFX1()
    {
        _rockBoomAudioSource.clip = _rock_Boom_SFX;
        _rockBoomAudioSource.Play();
    }
    private void RockBoomSFX2()
    {
        _rockBoomAudioSource2.clip = _rock_Boom_SFX;
        _rockBoomAudioSource2.Play();
    }
    IEnumerator BombTimer(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            if (i == 1)
            {
                AudioLevelEventStart();
                _bombFXStart.Invoke();
            }
            if (i == 2)
            {
                AudioLevelEventEnd();
                _bombFXMid.Invoke();
            }
            i++;
            yield return new WaitForSeconds(1);
        }
        _bombFXEnd.Invoke();
    }
}
