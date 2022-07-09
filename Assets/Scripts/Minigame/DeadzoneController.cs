using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadzoneController : MonoBehaviour
{
    private BuildingBlockManager blockManager;
    void Start()
    {
        blockManager = FindObjectOfType<BuildingBlockManager>();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Block"))
        {
            blockManager.RestartGame();
        }
    }
}
