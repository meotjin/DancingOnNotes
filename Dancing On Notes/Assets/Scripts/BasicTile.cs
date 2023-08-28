using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BasicTile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _notes;
    private MomentumController _momentumController1;
    private MomentumController _momentumController2;
    [SerializeField] private float _point;
    [SerializeField] private float _penalty;

    private void Awake()
    {
        _momentumController1 = GameObject.Find("Momentum1").GetComponent<MomentumController>();
        _momentumController2 = GameObject.Find("Momentum2").GetComponent<MomentumController>();
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
            _momentumController1.ChangeMomentum(_point);
            _momentumController2.ChangeMomentum(_point);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Destructor"))
        {
            _momentumController1.ChangeMomentum(_penalty);
            _momentumController2.ChangeMomentum(_penalty);
            Destroy(gameObject);
        }
    }
}
