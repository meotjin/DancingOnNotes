using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _memory;

    private void Awake()
    {
        _memory = _speed;
    }
    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    public void Stop()
    {
        _speed = 0;
    }

    public void Move()
    {
        _speed = _memory;
    }
}
