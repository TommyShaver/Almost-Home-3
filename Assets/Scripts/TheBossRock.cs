using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TheBossRock : MonoBehaviour
{
    private int _rockHealth = 30;
    private float _speed = 2f;

    public AudioSource _rockTakingDamage;
    public UnityEvent _theRockIsDead;

    private void Start()
    {
        _rockTakingDamage = GetComponent<AudioSource>();   
    }

    private void Update()
    {
        transform.Rotate(Vector3.back, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Laser") || collision.gameObject.tag == ("Bomb"))
        {
            _rockHealth--;
            _rockTakingDamage.Play();
        }
        if(collision.gameObject.tag == ("Bomb"))
        {
            _rockHealth = _rockHealth - 20;
        }
        if(_rockHealth <= 0)
        {
            _theRockIsDead.Invoke();
        }
        Debug.Log(_rockHealth);
    }
    
}
