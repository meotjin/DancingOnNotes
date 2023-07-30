using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorGiz : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 5.0f;

    void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
