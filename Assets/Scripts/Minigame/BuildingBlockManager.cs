using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlockManager : MonoBehaviour
{
    [SerializeField] private GameObject buildingBlock;
    [SerializeField] private GameObject winChecker;
    [SerializeField] private Vector3 defaultPosition;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        } else if (Input.anyKey && !blockedSpawning)
        {
            blockedSpawning = true;
            Invoke("SpawnBuildingBlock", 3);
        }
    }

    void SpawnBuildingBlock()
    {
        int spawnedBlocks = GameObject.FindGameObjectsWithTag("Block").Length;

        if (spawnedBlocks >= maxBlocks) return;
        if (spawnedBlocks == maxBlocks - 1) Invoke("SpawnWinChecker", 1);

        Vector3 spawnPosition = spawnedBlocks == 0 ? new Vector3(0, 0, 0) : defaultPosition;
        
        blockedSpawning = false;
        Instantiate(buildingBlock, spawnPosition, Quaternion.identity);
    }

    void SpawnWinChecker()
    {
        Debug.Log("Spawned Win Checker");
        Instantiate(winChecker, new Vector3(0, -0.5f, 0), Quaternion.identity);
    }

    void RestartGame()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        
        foreach (GameObject block in blocks)
        {
            GameObject.Destroy(block);
        }

        // GameObject winChecker = GameObject.FindWithTag();
    }
}
