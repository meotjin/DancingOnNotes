using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestAudioGenerator : MonoBehaviour
{
    private List<float> _laps;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _tile;
    [SerializeField] private float _delay = 0;
    private int index = 0;

    private void Awake()
    {       
        _laps = new List<float> { 3.3f, 4.3f, 4.7f, 5.2f, 5.6f, 7.0f, 7.4f, 7.9f, 8.3f, 8.7f,
            9.2f, 10.6f, 11f, 11.5f, 12.1f, 12.4f, 12.8f, 14.2f, 14.7f, 15.1f, 15.55f, 16f,
            16.5f, 17f, 17.2f, 17.4f, 17.64f, 17.84f, 19.2f, 19.68f, 21f, 21.5f, 22.4f, 23.35f,
            24.45f, 24.65f, 24.9f, 25.1f, 26.64f, 26.9f, 28.75f, 31.47f, 31.67f, 31.9f, 32.12f,
            32.35f, 33.3f, 33.73f, 34.2f, 34.65f, 36f, 36.45f, 36.9f, 37.1f, 37.4f, 37.64f,
            37.8f, 38.25f, 39.6f, 40f, 40.52f, 41.2f, 41.45f, 41.9f, 43.25f, 43.7f, 44.15f,
            44.61f, 44.85f, 45.1f, 45.5f, 46.46f, 46.9f, 48.25f, 48.7f, 50f, 50.3f, 50.6f,
            50.95f, 51.9f, 52.3f, 51.45f, 53.4f, 53.73f, 53.94f, 54.1f, 55f, 55.48f, 55.95f,
            56.4f, 57.8f, 58.23f, 58.7f, 59.2f, 59.55f, 59.9f };
    }

    void Update()
    {
        if (_audioSource.time > 62f)
        {
            SceneManager.LoadScene(0);
        }
        if (_laps[index] <= _audioSource.time + _delay) 
        {
            index++;
            Instantiate(_tile,transform.position, _tile.transform.rotation);
        }
    }
}
