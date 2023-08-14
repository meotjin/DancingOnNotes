using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MultiTapTile : MonoBehaviour
{
    [SerializeField] private List<float> _times;
    [SerializeField] private int _lives;
    [SerializeField] private GameObject _notes;
    private int _hits;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private PlatformController _platform;
    [SerializeField] private GameObject _Ring;
    [SerializeField] private GameObject _canvas;
    private bool _isTrigered;

    private void Start()
    {
        _hits = 0;
        _isTrigered = false;
        _Ring.GetComponent<MultiTapRings>().SetTimes(_times);
        _Ring.GetComponent<MultiTapRings>().SetTile(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            _hits++;
            Instantiate(_notes, transform.position, _notes.transform.rotation);
        }
        else if (collision.gameObject.CompareTag("Destructor"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (transform.position.y <= _playerPosition.position.y && !_isTrigered)
        {
            _isTrigered = true;
            _platform.Stop();
            Instantiate(_Ring,_Ring.GetComponent<RectTransform>().anchoredPosition, _Ring.transform.rotation, _canvas.transform);
        }

        if (_hits == _lives)
        {
            Destruct();
        }
    }

    public void Destruct()
    {
        _platform.Move();
        Destroy(gameObject);
    }
}
