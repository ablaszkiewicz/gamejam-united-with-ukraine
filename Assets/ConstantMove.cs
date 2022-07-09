using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private bool hasStarted = false;
    
    private void Update()
    {
        if (!hasStarted)
        {
            return;
        }
        
        transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
    }

    public void StartMoving()
    {
        hasStarted = true;
    }
    
    public void StopMoving()
    {
        hasStarted = false;
    }
}
