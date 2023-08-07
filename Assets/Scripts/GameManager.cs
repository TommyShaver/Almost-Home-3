using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private PlayerControls _player;

    public ParticleSystem _explosion;
    public UnityEvent _laserHitingRocksData;
    public UnityEvent _laserHittingRockSFX;
    public UnityEvent _inGameTimeEvent1;
    public UnityEvent _inGameTimeEvent2;
    public UnityEvent _inGameTimeEvent3;
    public UnityEvent _inGameTimeEvent4;
    public UnityEvent _WarningSFXLights;

    public void AstroidDestroyed(Asteroid asteroid)
    {
        this._explosion.transform.position = asteroid.transform.position;
        this._explosion.Play();
        _laserHitingRocksData.Invoke();
        _laserHittingRockSFX.Invoke();
    }

    private void Start()
    {
        StartCoroutine(GameTimer(300));
        // Hides the cursor...
        Cursor.visible = false;
    }

    IEnumerator GameTimer(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            if(i == 60)
            {
                _inGameTimeEvent1.Invoke();
            }

            if(i == 175)
            {
                _WarningSFXLights.Invoke();
            }
            if (i == 180)
            {
                _inGameTimeEvent2.Invoke();
            }

            if (i == 240)
            {
                _inGameTimeEvent3.Invoke();
            }
            if (i == 255)
            {
                _WarningSFXLights.Invoke();
            }
            if (i == 300)
            {
                _inGameTimeEvent4.Invoke();
            }
            i++;
            yield return new WaitForSeconds(1);
            Debug.Log(i);
        }
    }
    public void StopTheTimer()
    {
        StopAllCoroutines();
    }
}
