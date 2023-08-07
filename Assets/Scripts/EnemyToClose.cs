using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add pitch bend for enemy to close please!!!
public class EnemyToClose : MonoBehaviour
{
    private int _rockToClose = 0;
    private float _minVolume = 0f;
    private float _maxVolume = 0.5f;
    private float _fadeInDuration = .2f;
    private float _fadeOutDuration = .2f;


    [SerializeField] AudioSource _enemyToCloseSFXAduioScorue;
    [SerializeField] AudioReverbFilter _reverb;

    private IEnumerator _fadein;
    private IEnumerator _fadeout;

    private void Awake()
    {
        _reverb = GetComponent<AudioReverbFilter>();
        
        _reverb.dryLevel = 0;
        _reverb.reverbLevel = -4000;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            _rockToClose++;
            _enemyToCloseSFXAduioScorue.Play();
            _fadein = FadeIn(_enemyToCloseSFXAduioScorue, _fadeInDuration, _maxVolume);
            StartCoroutine(_fadein);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            _rockToClose--;
            if (_rockToClose == 0)
            {
                _fadeout = FadeOut(_enemyToCloseSFXAduioScorue, _fadeOutDuration, _minVolume);
                if(_enemyToCloseSFXAduioScorue.isPlaying)
                {
                    StopCoroutine(_fadein);
                    StartCoroutine(_fadeout);
                }
            }
        }
    }

    public void BombFXReverbStart()
    {
        _reverb.dryLevel = -10000;
        _reverb.reverbLevel = -1440;
    }
    public void BombFXReverbEnd()
    {
        _reverb.dryLevel = 0;
        _reverb.reverbLevel = -4000;
    }

    IEnumerator FadeIn(AudioSource _aScoure, float _durination, float _tragetVolume)
    {
        float _timer = 0f;
        float _currentVolume = _aScoure.volume;
        float _targetValue = Mathf.Clamp(_tragetVolume, _minVolume, _maxVolume);

        while(_timer < _durination)
        {
            _timer += Time.deltaTime;
            var _newVolume = Mathf.Lerp(_currentVolume, _targetValue, _timer / _durination);
            _aScoure.volume = _newVolume;
            yield return null;
        }
    }

    IEnumerator FadeOut(AudioSource _aScoure, float _durination, float _tragetVolume)
    {
        float _timer = 0f;
        float _currentVolume = _aScoure.volume;
        
        float _targetValue = Mathf.Clamp(_tragetVolume, _minVolume, _maxVolume);

        while (_aScoure.volume > 0)
        {
            _timer += Time.deltaTime;
            var _newVolume = Mathf.Lerp(_currentVolume, _targetValue, _timer / _durination);
            _aScoure.volume = _newVolume;
            yield return null;
        }
    }
}
