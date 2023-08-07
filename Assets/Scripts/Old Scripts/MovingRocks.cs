using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRocks : MonoBehaviour
{
    [SerializeField] float _rocksSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        _rocksSpeed = Random.Range(1, 9);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime *_rocksSpeed, Space.World);
    }
}
