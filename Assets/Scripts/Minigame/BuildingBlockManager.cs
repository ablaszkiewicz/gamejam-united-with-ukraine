using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlockManager : MonoBehaviour
{
    [SerializeField] private GameObject buildingBlock;
    [SerializeField] private GameObject winChecker;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private int maxBlocks = 4;

    private bool blockedSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBuildingBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !blockedSpawning)
        {
            blockedSpawning = true;
            Invoke("SpawnBuildingBlock", 3);
        }
    }

    void SpawnBuildingBlock()
    {
        int spawnedBlocks = GameObject.FindGameObjectsWithTag("Block").Length;

        if (spawnedBlocks >= maxBlocks) return;
        if (spawnedBlocks == maxBlocks) SpawnWinChecker();
        
        blockedSpawning = false;
        Instantiate(buildingBlock, spawnPosition, Quaternion.identity);
    }

    void SpawnWinChecker()
    {
        Debug.Log("Spawned Win Checker");
        Instantiate(winChecker, new Vector3(0, 0.7f, 0), Quaternion.identity);
    }
}
