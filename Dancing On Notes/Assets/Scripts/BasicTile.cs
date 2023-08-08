using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BasicTile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _notes;

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(_notes,transform.position,_notes.transform.rotation);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Destructor"))
        {
            Destroy(gameObject);
        }
    }
}
