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

    private BoxCollider2D _boxCollider2D;
    private CapsuleCollider2D _capsuleCollider2D;

    private void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            Debug.Log("Dead");
            _isDead = true;
            Destroy(this.gameObject);
            GameObject effect = Instantiate(_shipDeath, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            _playerHasFailed.Invoke();
            _shipdeathSFX.Invoke();
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
