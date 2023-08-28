using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    public ParticleSystem _explosion;
    public UnityEvent _laserHitingRocksData;
    public UnityEvent _laserHittingRockSFX;
    public UnityEvent _inGameTimeEvent1;
    public UnityEvent _inGameTimeEvent2;
    public UnityEvent _inGameTimeEvent3;
    public UnityEvent _inGameTimeEvent4;
    public UnityEvent _WarningSFXLights;
    public UnityEvent _endOfTimeEventsFinalBoss;
    public UnityEvent _scoreSFXGo;


    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _endscoreText;
    private int _score;

    public void AstroidDestroyed(Asteroid asteroid)
    {
        this._explosion.transform.position = asteroid.transform.position;
        this._explosion.Play();
        _laserHitingRocksData.Invoke();
        _laserHittingRockSFX.Invoke();
        UpdateScore(5);
    }

    private void Start()
    {
        StartCoroutine(GameTimer(300));
        // Hides the cursor...
        Cursor.visible = false;
        Time.timeScale = 1;
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
            if (i == 275)
            {
                _endOfTimeEventsFinalBoss.Invoke();
            }
            if (i == 299)
            {
                _inGameTimeEvent4.Invoke();
            }
            i++;
            yield return new WaitForSeconds(1);
        }
    }
    public void StopTheTimer()
    {
        StopAllCoroutines();
        Cursor.visible = true;
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = _score + " :Score";
        _endscoreText.text = "Score: " + _score;
        _scoreSFXGo.Invoke();
    }

    public void ResetGameButton()
    {
        SceneManager.LoadScene("StoryModeScene");
    }
}
