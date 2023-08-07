using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryRocks : MonoBehaviour
{
    [SerializeField] float _destroyY = -6;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBounds();
    }
    void DestroyOutOfBounds()
    {
        if(transform.position.y <= _destroyY)
        {
            Destroy(gameObject, 1f);
        }
    }
}
