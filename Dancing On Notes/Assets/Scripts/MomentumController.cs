using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class MomentumController : MonoBehaviour
{
    [SerializeField] private float _momentum;
    [SerializeField] private float _maxMomentum = 1000;
    [SerializeField] private float _baseMomentum = 200;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _momentum = _baseMomentum;
        _slider.value = _momentum;
    }

    private void Update()
    {
        _slider.value = _momentum;
        //_slider.value = Mathf.Lerp();
    }

    public void ChangeMomentum(float momentum)
    {
        _momentum += momentum;
        if (_momentum > _maxMomentum)
        {
            _momentum = _maxMomentum;
        }
        if (_momentum < 0) 
        { 
            _momentum = 0f;
        }
    }
}
