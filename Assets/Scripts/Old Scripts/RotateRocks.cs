using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRocks : MonoBehaviour
{
    [SerializeField] float _rockSpeed;
    [SerializeField] float _randomNumber;
    public GameObject rockParticles;


    public int _randomScaleNum;
    public GameObject[] _spawnRockPrefab;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Call Random Values for rocks
        _rockSpeed = Random.Range(10.0f, 90.0f);
        _randomNumber = Random.Range(-1, 1);
        _randomScaleNum = Random.Range(1, 11);
        _rb.mass = this._randomScaleNum;
        //Change localScale on spawn. 
        transform.localScale += new Vector3(_randomScaleNum, _randomScaleNum, 0);
        Debug.Log(_randomScaleNum);
        
    }

    // Update is called once per frame
    void Update()
    {

        // Change roation of rock
        if (_randomNumber == -1)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * _rockSpeed, Space.World);
        }
        else
        {
            transform.Rotate(Vector3.back * Time.deltaTime * _rockSpeed, Space.World);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.tag == "Laser")
        {
            if(_randomScaleNum >= 7)
            {
                int spawnIndex = Random.Range(0, _spawnRockPrefab.Length);
                Instantiate(_spawnRockPrefab[spawnIndex], transform.position, _spawnRockPrefab[spawnIndex].transform.rotation);
                Instantiate(_spawnRockPrefab[spawnIndex], transform.position, _spawnRockPrefab[spawnIndex].transform.rotation);
                Instantiate(_spawnRockPrefab[spawnIndex], transform.position, _spawnRockPrefab[spawnIndex].transform.rotation);
                Destroy(gameObject);
                Debug.Log("This worked.");
                GameObject _endOfLife = Instantiate(rockParticles, transform.position, transform.rotation);
                Destroy(_endOfLife, 5f);
            }
            else
            {
                Destroy(gameObject);
                GameObject _endOfLife = Instantiate(rockParticles, transform.position, transform.rotation);
                Destroy(_endOfLife, 5f);
            }
        }
    }

}
