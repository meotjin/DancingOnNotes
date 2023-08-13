using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
