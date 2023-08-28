using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] float _playerRotateSpeed;
    [SerializeField] float _horizontalInput;
    public UnityEvent _pauseGame;
    public UnityEvent _resumeGame;
    private bool _isgamePaused;
    private PlayerControls _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerControls>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_playerHealth._isDead == false)
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(_horizontalInput * _playerRotateSpeed * Time.deltaTime * Vector3.back);

            if(Input.GetKeyDown(KeyCode.P))
            {
                if(_isgamePaused == false)
                {
                    _isgamePaused = true;
                    _pauseGame.Invoke();
                    Time.timeScale = 0;
                }
                else
                {
                    _isgamePaused = false;
                    _resumeGame.Invoke();
                    Time.timeScale = 1;
                }
            }
        }
    }
}
