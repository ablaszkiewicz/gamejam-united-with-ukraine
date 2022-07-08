using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    private float delay = 3;
    private Coroutine _currentRoutine;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block")
        {
            Invoke("CheckWinCondition", 5);
        }
    }

    private void CheckWinCondition()
    {
        
    }
}
