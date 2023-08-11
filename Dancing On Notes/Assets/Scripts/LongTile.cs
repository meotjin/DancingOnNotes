using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongTile : MonoBehaviour
{
    [SerializeField] private float _speed;
    private HoldInputHandler _HoldInputHandler;
    private SpriteRenderer _spriteRenderer;
  
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _spriteRenderer.color = Color.green;
        }
        else if (collision.gameObject.CompareTag("Destructor"))
        {
            Destroy(gameObject);
        }
    }

    public void SetHoldInputHandler(HoldInputHandler inputHandler)
    {
        _HoldInputHandler = inputHandler;
    }
}

