using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BasicTile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _notes;
    private MomentumController _momentumController;
    [SerializeField] private float _point;
    [SerializeField] private float _penalty;

    private void Awake()
    {
        _momentumController = GameObject.Find("Momentum").GetComponent<MomentumController>();
    }

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
            _momentumController.ChangeMomentum(_point);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Destructor"))
        {
            _momentumController.ChangeMomentum(_penalty);
            Destroy(gameObject);
        }
    }
}
