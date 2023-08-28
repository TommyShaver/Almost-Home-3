using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    public bool _isDead = false;
    public GameObject _shipDeath;
    public UnityEvent _playerHasFailed;
    public UnityEvent _shipdeathSFX;
    public UnityEvent _shipLosesSheild;

    private BoxCollider2D _boxCollider2D;
    private CapsuleCollider2D _capsuleCollider2D;
    private Rigidbody2D _rb;
    private int _playerHealth = 2;


    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            _rb.velocity = Vector2.zero;
            _playerHealth--;
           if(_playerHealth == 1)
            {
                _shipLosesSheild.Invoke();
            }
            if (_playerHealth == 0)
            {
                Debug.Log("Dead");
                _isDead = true;
                Destroy(this.gameObject);
                GameObject effect = Instantiate(_shipDeath, transform.position, Quaternion.identity);
                Destroy(effect, 2f);
                _playerHasFailed.Invoke();
                _shipdeathSFX.Invoke();
            }
            Debug.Log("Player Health: " + _playerHealth);
        }
    }

    public void BombFXStart()
    {
        _boxCollider2D.enabled = false;
        _capsuleCollider2D.enabled = false;
    }

    public void BombFXEnd()
    {
        _boxCollider2D.enabled = true;
        _capsuleCollider2D.enabled = true;
    }
}
