using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public void Invoke()
    {
        Debug.Log("loaded");
    }

    public void Start()
    {
        Debug.Log("test");
    }
    
    public void Update()
    {
        Debug.Log("tick");
    }
}
