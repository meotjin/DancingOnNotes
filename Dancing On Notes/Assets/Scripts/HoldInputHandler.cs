using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldInputHandler : MonoBehaviour
{
    [SerializeField] AnimationCurve _curve;
    [SerializeField] private Vector3 _posA;
    [SerializeField] private Vector3 _posB;
    [SerializeField] private Vector3 _posC;
    [SerializeField] private float _speed = .5f;
    [SerializeField] private float _turnRange = 1f;
    private int _targetIndex;
    private float _current;

    private void Update()
    {
        bool isMouseButtonDown = Input.GetMouseButtonDown(0);
        bool isMouseButtonUp = Input.GetMouseButtonUp(0);

        bool isWithinTurnRange = Mathf.Abs(transform.position.x) > _turnRange;

        if (isMouseButtonDown && isWithinTurnRange)
        {
            // Cycle through target positions A, B, and C
            _targetIndex = (_targetIndex + 1) % 3;
        }

        if (isMouseButtonUp)
        {
            if (isWithinTurnRange)
            {
                // Reverse the target index when the mouse button is released
                _targetIndex = (_targetIndex + 2) % 3;
            }
            else
            {
                // If outside turn range, reset to original position
                _targetIndex = 0;
            }
        }

        _current = Mathf.MoveTowards(_current, _targetIndex, _speed * Time.deltaTime);

        Vector3 targetPosition;
        if (_targetIndex == 0)
        {
            targetPosition = _posA;
        }
        else if (_targetIndex == 1)
        {
            targetPosition = _posB;
        }
        else
        {
            targetPosition = _posC;
        }

        transform.position = Vector3.Lerp(_posA, targetPosition, _curve.Evaluate(_current));
    }
}
