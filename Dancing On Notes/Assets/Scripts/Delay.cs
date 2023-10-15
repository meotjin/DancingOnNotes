using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    [SerializeField] private float _delay;
    private void Awake()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(_delay);
    }

}
