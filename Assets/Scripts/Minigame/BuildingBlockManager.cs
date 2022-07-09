using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlockManager : MonoBehaviour
{
    [SerializeField] private GameObject buildingBlock;
    [SerializeField] private GameObject[] sprites;
    [SerializeField] private int maxBlocks = 4;
    private bool blockedSpawning = false;
    private float[] defaultPositions = {-2, 2};
    private HookController _hookController;
    
    // Start is called before the first frame update
    void Start()
    {
        _hookController = FindObjectOfType<HookController>();
        SpawnBuildingBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        } else if (Input.GetKeyDown(KeyCode.Space) && !blockedSpawning)
        {
            blockedSpawning = true;
            Invoke("SpawnBuildingBlock", 3);
            _hookController.GoUp();
        }
    }

    void SpawnBuildingBlock()
    {
        int spawnedBlocks = GameObject.FindGameObjectsWithTag("Block").Length;

        if (spawnedBlocks >= maxBlocks) return;

        float spawnPositionX = spawnedBlocks == 0 ? 0 : defaultPositions[Random.Range(0, defaultPositions.Length)];
        
        blockedSpawning = false;
        Instantiate(buildingBlock, new Vector3(spawnPositionX, 6, 0), Quaternion.identity);
    }

    public void RestartGame()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        
        foreach (GameObject block in blocks)
        {
            GameObject.Destroy(block);
        }

        CancelInvoke();
        Invoke("SpawnBuildingBlock", 3);
    }
}
