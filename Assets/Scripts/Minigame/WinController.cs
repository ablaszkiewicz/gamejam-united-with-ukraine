using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    private float delay = 3;
    private Coroutine _currentRoutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            Debug.Log("Starting Coroutine");
            _currentRoutine = StartCoroutine(BroadcastWin());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_currentRoutine != null)
        {
            Debug.Log("Stoping Coroutine");
            StopCoroutine(_currentRoutine);
        }
    }


    IEnumerator BroadcastWin()
    {
        yield return new WaitForSeconds(5f);
        
        Debug.Log("Won the game!");
    }
}
