using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    private float _intervalInMinutes = 5f;
    private int _points;
    private float _timer;
    private Task _currentTask;

    public void Start()
    {
        _timer = _intervalInMinutes * 60f;
    }
    
    public void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _currentTask.everyDay(10);
            _timer = _intervalInMinutes * 60f;
        }
    }
}
