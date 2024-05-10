using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _start;
    public float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _start = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float change = Camera.main.transform.position.x * _speed;
        transform.position = new Vector3(_start + change, transform.position.y, transform.position.z);
    }
}
