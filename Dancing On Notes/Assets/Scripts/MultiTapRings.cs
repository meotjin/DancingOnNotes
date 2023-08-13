using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MultiTapRings : MonoBehaviour
{
    [SerializeField] private GameObject _green;
    [SerializeField] private GameObject _blue;
    [SerializeField] private List<float> _times;

    private bool _enabled = true;
    private bool _perfection = false;
    private int _index = 0;
    private float _rate;

    private void Start()
    {
        init();
    }

    private void FixedUpdate()
    {
        _blue.transform.localScale -= new Vector3(_rate,_rate,_rate);;
    }

    private void Update()
    {
        _perfection = Mathf.Abs(_blue.transform.localScale.x - _green.transform.localScale.x) <= 0.4 ? true : false;

        if (_index > _times.Count)
        {
            Destroy(gameObject);
        }
        else if (_blue.transform.localScale.x <= 1)
        {
             _blue.transform.localScale = new Vector3(10,10,10);
             init();
        }
    }

    void init()
    {
        _rate = 0.02f * (_blue.transform.localScale.x - _green.transform.localScale.x + 2) / _times[_index++];
        _enabled = true;
    }
}
