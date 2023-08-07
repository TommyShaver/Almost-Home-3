using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] float _playerRotateSpeed;
    [SerializeField] float _horizontalInput;


    //This is how you do this. 
    public ParticleSystem _partSystem;

    private PlayerControls _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerControls>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _partSystem.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_playerHealth._isDead == false)
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(_horizontalInput * _playerRotateSpeed * Time.deltaTime * Vector3.back);
        }
        if(_playerHealth._isDead == true)
        {
            _partSystem.Stop();
        }

    }

    
}
