using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuildingBlockManager : MonoBehaviour
{
    [SerializeField] private GameObject buildingBlock;
    [SerializeField] private GameObject[] sprites;
    [SerializeField] private int maxBlocks = 4;
    private bool blockedSpawning = false;
    private float[] defaultPositions = {-2, 2};
    private HookController _hookController;

    [SerializeField] private Dialogue dialogue;
    private DialoguePanel dialoguePanel;
    private SceneTransitionManager sceneTransitionManager;
    private bool gameStarted = false;

    private void Awake()
    {
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
        _hookController = FindObjectOfType<HookController>();
    }
    
    void Start()
    {
        dialoguePanel = FindObjectOfType<DialoguePanel>();
        dialoguePanel.LoadDialogue(dialogue);
        dialoguePanel.OnDialogueFinished += StartGame;
        dialoguePanel.Show();
    }

    private void StartGame()
    {
        if (gameStarted)
        {
            return;
        }

        gameStarted = true;
        Debug.Log("Starting");
        SpawnBuildingBlock();   
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && !blockedSpawning)
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
        sceneTransitionManager.TransitionToScene(SceneType.MiniGame);

        // GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        //
        // foreach (GameObject block in blocks)
        // {
        //     GameObject.Destroy(block);
        // }
        //
        // CancelInvoke();
        // Invoke("SpawnBuildingBlock", 3);
    }
}
