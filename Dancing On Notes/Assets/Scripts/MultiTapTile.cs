using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTapTile : MonoBehaviour
{
    [SerializeField] private List<float> _times;
    [SerializeField] private int _lives;
    [SerializeField] private GameObject _notes;
    private int _hits;

    private void Start()
    {
        _hits = 0;
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
        if (_hits == _lives)
        {
            Destroy(gameObject);
        }
    }
}
