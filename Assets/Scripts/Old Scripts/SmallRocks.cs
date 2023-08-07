using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRocks : MonoBehaviour
{
    [SerializeField] float _rockSpeed;
    [SerializeField] float _randomNumber;
    public GameObject rockParticles;
    // Start is called before the first frame update
    void Start()
    {
        _rockSpeed = Random.Range(10.0f, 90.0f);
        _randomNumber = Random.Range(-1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (_randomNumber == -1)
        {
            transform.Rotate(_rockSpeed * Time.deltaTime * Vector3.forward);
        }
        else
        {
            transform.Rotate(_rockSpeed * Time.deltaTime * Vector3.back);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
            GameObject _endOfLife = Instantiate(rockParticles, transform.position, transform.rotation);
            Destroy(_endOfLife, 2f);
        }
    }
}
