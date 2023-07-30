using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTestTile : MonoBehaviour
{
    [SerializeField] private GameObject _tile;
    [SerializeField] private float _rate;
    private void Awake()
    {
        InvokeRepeating("Generate", 0, _rate);
    }

    private void Generate()
    {
        Instantiate(_tile,transform.position,transform.rotation);
    }
}
