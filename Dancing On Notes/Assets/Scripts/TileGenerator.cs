using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileGenerator : MonoBehaviour
{
    private float[] _laps;
    [SerializeField] public String _txtFilename;
    [SerializeField] private GameObject _tile;
    [SerializeField] private float _delay = 0;
    // private float _time = 0.0f;
    private int index = 0;
    [SerializeField] private GameObject _platform;
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        var numbers = File.ReadAllLines(_txtFilename);
        _laps = numbers.Where(s => s != String.Empty).Select(s => float.Parse(s, CultureInfo.InvariantCulture)).ToArray();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > 73)
        {
            _gameManager.Finish();
        }
    }
    private void LateUpdate()
    {
        if (_laps[index] + _delay <= Time.timeSinceLevelLoad)
        {
            index++;
            Instantiate(_tile, transform.position, _tile.transform.rotation, _platform.transform);
        }
    }
}