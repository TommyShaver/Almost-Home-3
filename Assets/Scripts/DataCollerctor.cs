using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DataCollerctor : MonoBehaviour
{
    private bool _bombReadyToLanuch;
    
    public int _howManyShotsFired = 0;
    public int _howManyBombsShot = 0;
    public int _shotsThatHitRocks = 0;
    public int _howManyShotsWentIntoVoid = 0;
    public int _howManyRocksSpwaned = 0;
    public int _score = 0;

    public UnityEvent _bomb_SFX_Event_Start;
    public UnityEvent _bomb_SFX_Event_Over;
    public UnityEvent _returnMusic;
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BombIsReady(30));
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetButtonDown("Fire1"))
            {
                _howManyShotsFired++;
            }
            if (Input.GetKeyDown(KeyCode.B) && _bombReadyToLanuch == true)
            {
                _howManyBombsShot++;
                _bomb_SFX_Event_Start.Invoke();
                StartCoroutine(BombIsReady(30));
            }
    }

    IEnumerator BombIsReady(int _timer)
    {
        int i = 0;
        while (i < _timer)
        {
            _bombReadyToLanuch = false;
            i++;
            if (i == 4)
            {
                _bomb_SFX_Event_Over.Invoke();
                Debug.Log("Data Coloerctor just launch _returnMusic Event");
            }
            yield return new WaitForSeconds(1);
        }
        _bomb_SFX_Event_Over.Invoke();
        _bombReadyToLanuch = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            _howManyShotsWentIntoVoid++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            _howManyRocksSpwaned++;
        }
    }
    public void ShotDeceted()
    {
        _shotsThatHitRocks++;
    }
    public void PlayerScore()
    {
        _score = _score + 5;
    }
}
