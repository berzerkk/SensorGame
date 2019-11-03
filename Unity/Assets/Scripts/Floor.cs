using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public float _speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - _speed, transform.position.y, transform.position.z);
        if (transform.position.x <= -3f)
            transform.position = new Vector3(4.5f, transform.position.y, transform.position.z);
    }
}
