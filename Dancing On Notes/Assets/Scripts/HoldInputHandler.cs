using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldInputHandler : MonoBehaviour
{
        private float _HoldDownStartTime;
    public float _Holdtime;
    [SerializeField] LongTile LongTile;
    
    private void Start()
    {
        LongTile.SetHoldInputHandler(this);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _HoldDownStartTime = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _Holdtime = Time.time - _HoldDownStartTime;
            _HoldDownStartTime = 0f;
        }
    }
}
