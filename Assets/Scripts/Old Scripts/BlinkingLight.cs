
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlinkingLight : MonoBehaviour
{
    [SerializeField] float fadeOutTimer = 5.0f;



    private void Start()
    {
        StartCoroutine(FadeOut(GetComponent<SpriteRenderer>()));
    }

    IEnumerator FadeOut (SpriteRenderer _sprite)
    {
        Color tmpColor = _sprite.color;
        while(tmpColor.a >0f)
        {
            tmpColor.a -= Time.deltaTime / fadeOutTimer;
            _sprite.color = tmpColor;
            if (tmpColor.a <= 0f)
                tmpColor.a = 0.0f;
            yield return null;
        }
        _sprite.color = tmpColor;
    }
}
