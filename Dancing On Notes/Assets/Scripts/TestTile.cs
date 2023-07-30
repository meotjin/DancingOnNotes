using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTile : MonoBehaviour
{
    [SerializeField] private float _speed;
  
    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (collision.gameObject.CompareTag("Destructor"))
        {
            Destroy(gameObject);
        }
    }
}
