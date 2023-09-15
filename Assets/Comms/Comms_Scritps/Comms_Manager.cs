using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Comms_Manager : MonoBehaviour
{
    public UnityEvent _fadeInComms;
    public UnityEvent _staticAnim;
    public UnityEvent _monSprite;
    public UnityEvent _tomSprite;
    public UnityEvent _fadeOutComms;
    public UnityEvent _clearAllBoolsAnim;
    public UnityEvent _startTextBoxAnim;
    public UnityEvent _clearTextBoxAnim;
   

    public AudioClip _monIntro;
    public AudioClip _ourBombIsREadyFirstTime;
    public AudioClip _bombIsReady;
    public AudioClip _sheildsAreGone;
    public AudioClip _slowMovingCluster;
    public AudioClip _thickestPartOfBelt;
    public AudioClip _LookOutMonBoss;
    public AudioClip _fixedItEndOfGame;
    public AudioClip _commsAlertIn;
    public AudioClip _commsAlertOut;

    private AudioSource _commsAudioSource;
    private bool _bombIsReadyFirstTime;

    private void Awake()
    {
        _commsAudioSource = GetComponent<AudioSource>();
    }

    public void StartOfGame()
    {
        StartCoroutine(IntoGameComms(15));
        _commsAudioSource.clip = _commsAlertIn;
        _commsAudioSource.Play();
        _fadeInComms.Invoke();
    }

    public void BombIsReady()
    {
        if (_bombIsReadyFirstTime == false)
        {
            _bombIsReadyFirstTime = true;
            StartCoroutine(BombFirstTime(8));
            _commsAudioSource.clip = _commsAlertIn;
            _commsAudioSource.Play();
            _fadeInComms.Invoke();
        }
        else
        {
            StartCoroutine(BombIsReady(4));
            _commsAudioSource.clip = _commsAlertIn;
            _commsAudioSource.Play();
            _fadeInComms.Invoke();
        }
    }

    public void ShipSheildsAreGone()
    {
        StartCoroutine(ShieldsAreGone(7));
        _commsAudioSource.clip = _commsAlertIn;
        _commsAudioSource.Play();
        _fadeInComms.Invoke();
    }

    public void ClusterOfSlowMovingAStroids()
    {
        StartCoroutine(SlowMovingRocks(6));
        _commsAudioSource.clip = _commsAlertIn;
        _commsAudioSource.Play();
        _fadeInComms.Invoke();
    }

    public void ThickestPartOfBelt()
    {
        StartCoroutine(ThickestPartOfBelt(5));
        _commsAudioSource.clip = _commsAlertIn;
        _commsAudioSource.Play();
        _fadeInComms.Invoke();
    }

    public void LookOutBigAstroid()
    {
        StartCoroutine(FinalBossRock(8));
        _commsAudioSource.clip = _commsAlertIn;
        _commsAudioSource.Play();
        _fadeInComms.Invoke();
    }

    public void PuaseCommsAudio()
    {
        _commsAudioSource.Pause();
    }

    public void ResumeCommsAudio()
    {
        _commsAudioSource.Play();
    }

    IEnumerator IntoGameComms(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            i++;
            if (i == 2)
            {
                Comms_Dialog_Box._comms_Dialog_Box.StartDialogueBoxOne();
                _monSprite.Invoke();
                _commsAudioSource.clip = _monIntro;
                _commsAudioSource.Play();
            }
            if(i == 14)
            {
                Comms_Dialog_Box._comms_Dialog_Box.EmptyTextBox();
                _commsAudioSource.clip = _commsAlertOut;
                _commsAudioSource.Play();
                _fadeOutComms.Invoke();
            }
            yield return new WaitForSeconds(1);
        }
        _clearAllBoolsAnim.Invoke();
    }

    IEnumerator BombFirstTime(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            i++;
            if (i == 2)
            {
                Comms_Dialog_Box._comms_Dialog_Box.OurBombSystemReady();
                _monSprite.Invoke();
                _commsAudioSource.clip = _ourBombIsREadyFirstTime;
                _commsAudioSource.Play();
            }
            if (i == 7)
            {
                Comms_Dialog_Box._comms_Dialog_Box.EmptyTextBox();
                _clearTextBoxAnim.Invoke();
                _commsAudioSource.clip = _commsAlertOut;
                _commsAudioSource.Play();
                _fadeOutComms.Invoke();
            }
            yield return new WaitForSeconds(1);
        }
        _clearAllBoolsAnim.Invoke();
    }

    IEnumerator BombIsReady(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            i++;
            if (i == 2)
            {
                Comms_Dialog_Box._comms_Dialog_Box.BombIsReady();
                _monSprite.Invoke();
                _commsAudioSource.clip = _bombIsReady;
                _commsAudioSource.Play();
            }
            if (i == 4)
            {
                Comms_Dialog_Box._comms_Dialog_Box.EmptyTextBox();
                _clearTextBoxAnim.Invoke();
                _commsAudioSource.clip = _commsAlertOut;
                _commsAudioSource.Play();
                _fadeOutComms.Invoke();
            }
            yield return new WaitForSeconds(1);
        }
        _clearAllBoolsAnim.Invoke();
    }

    IEnumerator ShieldsAreGone(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            i++;
            if (i == 2)
            {
                Comms_Dialog_Box._comms_Dialog_Box.SheildsAreGone();
                _monSprite.Invoke();
                _commsAudioSource.clip = _sheildsAreGone;
                _commsAudioSource.Play();
            }
            if (i == 6)
            {
                Comms_Dialog_Box._comms_Dialog_Box.EmptyTextBox();
                _clearTextBoxAnim.Invoke();
                _commsAudioSource.clip = _commsAlertOut;
                _commsAudioSource.Play();
                _fadeOutComms.Invoke();
            }
            yield return new WaitForSeconds(1);
        }
        _clearAllBoolsAnim.Invoke();
    }
    IEnumerator SlowMovingRocks(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            i++;
            if (i == 2)
            {
                Comms_Dialog_Box._comms_Dialog_Box.SlowMovingRocks();
                _monSprite.Invoke();
                _commsAudioSource.clip = _slowMovingCluster;
                _commsAudioSource.Play();
            }
            if (i == 5)
            {
                Comms_Dialog_Box._comms_Dialog_Box.EmptyTextBox();
                _clearTextBoxAnim.Invoke();
                _commsAudioSource.clip = _commsAlertOut;
                _commsAudioSource.Play();
                _fadeOutComms.Invoke();
            }
            yield return new WaitForSeconds(1);
        }
        _clearAllBoolsAnim.Invoke();
    }
    IEnumerator ThickestPartOfBelt(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            i++;
            if (i == 2)
            {
                Comms_Dialog_Box._comms_Dialog_Box.WeAreGettingToThickest();
                _monSprite.Invoke();
                _commsAudioSource.clip = _thickestPartOfBelt;
                _commsAudioSource.Play();
            }
            if (i == 4)
            {
                Comms_Dialog_Box._comms_Dialog_Box.EmptyTextBox();
                _clearTextBoxAnim.Invoke();
                _commsAudioSource.clip = _commsAlertOut;
                _commsAudioSource.Play();
                _fadeOutComms.Invoke();
            }
            yield return new WaitForSeconds(1);
        }
        _clearAllBoolsAnim.Invoke();
    }
    IEnumerator FinalBossRock(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            i++;
            if (i == 2)
            {
                Comms_Dialog_Box._comms_Dialog_Box.FinalBossText();
                _monSprite.Invoke();
                _commsAudioSource.clip = _LookOutMonBoss;
                _commsAudioSource.Play();
            }
            if (i == 7)
            {
                Comms_Dialog_Box._comms_Dialog_Box.EmptyTextBox();
                _clearTextBoxAnim.Invoke();
                _commsAudioSource.clip = _commsAlertOut;
                _commsAudioSource.Play();
                _fadeOutComms.Invoke();
            }
            yield return new WaitForSeconds(1);
        }
        _clearAllBoolsAnim.Invoke();
    }
}
