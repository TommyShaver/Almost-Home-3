using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] rockPrefabs;

    [SerializeField] float _spawnYPos = 6;
    [SerializeField] float _sideSpawnYPos = 4;
    [SerializeField] float _spawnXPos = 10;
    [SerializeField] float _spawnDelay;
    [SerializeField] float _spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRocksDown", _spawnDelay, _spawnInterval);
        //InvokeRepeating("SpawnRocksLeft", _spawnDelay, _spawnInterval);
        //InvokeRepeating("SpawnRocksRight", _spawnDelay, _spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRocksDown()
    {
        int rockIndex = Random.Range(0, rockPrefabs.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-_spawnXPos,_spawnXPos), _spawnYPos);
        Instantiate(rockPrefabs[rockIndex], spawnPos, rockPrefabs[rockIndex].transform.rotation);
    }
    void SpawnRocksLeft()
    {
        int rockIndex = Random.Range(0, rockPrefabs.Length);
        Vector2 spawnPos = new Vector2(-11, Random.Range(-_sideSpawnYPos, _sideSpawnYPos));
        Vector2 turnRotation = new Vector2(0, 90);
        Instantiate(rockPrefabs[rockIndex], spawnPos, Quaternion.Euler(turnRotation));
    }
    void SpawnRocksRight()
    {
        int rockIndex = Random.Range(0, rockPrefabs.Length);
        Vector2 spawnPos = new Vector2(11, Random.Range(-_sideSpawnYPos, _sideSpawnYPos));
        Vector2 turnRotation = new Vector2(0, -90);
        Instantiate(rockPrefabs[rockIndex], spawnPos, Quaternion.Euler(turnRotation));
    }
}
