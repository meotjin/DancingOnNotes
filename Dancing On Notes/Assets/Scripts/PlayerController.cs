using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AnimationCurve _curve;
    [SerializeField] private Vector3 _posA;
    [SerializeField] private Vector3 _posB;
    [SerializeField] private float _speed = .5f;
    [SerializeField] private float _turnRange = 1f;
    private bool _canMove = true;
    private float _current, _target;
    private bool _canTurn;
    [SerializeField] private float _movePenalty = -20f;
    [SerializeField] private MomentumController _MomentumController1;
    [SerializeField] private MomentumController _MomentumController2;

    private void Update()
    {
        _canTurn = Mathf.Abs(transform.position.x) > _turnRange ? true : false;

        if (Input.GetMouseButtonDown(0) && _canTurn && _canMove)
        {
            _target = _target == 0 ? 1 : 0;
            _MomentumController1.ChangeMomentum(_movePenalty);
            _MomentumController2.ChangeMomentum(_movePenalty);
        }
           
        _current = Mathf.MoveTowards(_current, _target, _speed * Time.deltaTime);
        transform.position = Vector3.Lerp(_posA, _posB, _curve.Evaluate(_current));   
    }

    public void CanMove()
    {
        _canMove = true;
    }

    public void CantMove()
    {
        _canMove = false;
    }
}
