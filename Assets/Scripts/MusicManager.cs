using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioLowPassFilter _lowPassAudioFilter;
    private IEnumerator _fadein;
    private IEnumerator _fadeout;
    private float _minFrequency = 100f;
    private float _maxFrequency = 20000f;
    private float _fadeInDuration = 1f;
    private float _fadeOutDuration = 1f;

    private void Start()
    {
        _lowPassAudioFilter = GetComponent<AudioLowPassFilter>();
    }


    public void StartMusicFilteringDown()
    {
        _fadeout = FadeOut(_lowPassAudioFilter, _fadeOutDuration, _minFrequency);
        StartCoroutine(_fadeout);
    }

    public void StartMusicFilteringUp()
    {
        _fadein = FadeIn(_lowPassAudioFilter, _fadeInDuration, _maxFrequency);
        StartCoroutine(_fadein);
    }


    IEnumerator FadeIn(AudioLowPassFilter _filter, float _durination, float _tragetFrequency)
    {
        float _timer = 0f;
        float _currentFrequency = _filter.cutoffFrequency;
        float _targetValue = Mathf.Clamp(_tragetFrequency, _minFrequency, _maxFrequency);

        while (_timer < _durination)
        {
            _timer += Time.deltaTime;
            var _newFrequency = Mathf.Lerp(_currentFrequency, _targetValue, _timer / _durination);
            _filter.cutoffFrequency = _newFrequency;
            yield return null;
        }
    }

    IEnumerator FadeOut(AudioLowPassFilter _filter, float _durination, float _tragetFrequency)
    {
        float _timer = 0f;
        float _currentFrequency = _filter.cutoffFrequency;
        float _targetValue = Mathf.Clamp(_tragetFrequency, _minFrequency, _maxFrequency);

        while (_filter.cutoffFrequency > 200)
        {
            _timer += Time.deltaTime;
            var _newFrequency = Mathf.Lerp(_currentFrequency, _targetValue, _timer / _durination);
            _filter.cutoffFrequency = _newFrequency;
            yield return null;
        }
    }
}
