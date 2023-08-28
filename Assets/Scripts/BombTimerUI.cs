using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombTimerUI : MonoBehaviour
{

    private Image _image;
    private float _minFillAmount = 0f;
    private float _maxFillAmount = 1f;
    private float _countingTimerUp = 30f;
    IEnumerator _startCounting;
   

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1f;
    }
    public void ResetCallToTimerFill()
    {
        _image.fillAmount = 0f;
        _startCounting = StartToFillBombBar(_image, _countingTimerUp, _maxFillAmount);
        StartCoroutine(_startCounting);
    }


    // Start is called before the first frame update
    IEnumerator StartToFillBombBar(Image _image, float _durination, float _tragetFill)
    {
        float _timer = 0f;
        float _currentFillAmount = _image.fillAmount;
        float _targetValue = Mathf.Clamp(_tragetFill, _minFillAmount, _maxFillAmount);

        while (_timer < _durination)
        {
            _timer += Time.deltaTime;
            var _newFillAmount = Mathf.Lerp(_currentFillAmount, _targetValue, _timer / _durination);
            _image.fillAmount = _newFillAmount;
            yield return null;
        }
    }
}
