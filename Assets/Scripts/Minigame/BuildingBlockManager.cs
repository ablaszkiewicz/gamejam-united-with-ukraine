using System;
using System.Collections;
using System.Collections.Generic;
using Menu;
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
    [SerializeField] private BasicPanel gameOverPanel;
    [SerializeField] private MinigamesStatus status;
    
    private DialoguePanel dialoguePanel;
    private SceneTransitionManager sceneTransitionManager;
    private AudioSource _audioSource;
    private bool gameStarted = false;

    private void Awake()
    {
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
        _hookController = FindObjectOfType<HookController>();
        
    }
    
    void Start()
    {
        dialoguePanel = FindObjectOfType<DialoguePanel>();
        _audioSource = GetComponent<AudioSource>();

        if (!status.GetVisitStatus(SceneType.MiniGame))
        {
            dialoguePanel.LoadDialogue(dialogue);
            dialoguePanel.OnDialogueFinished += StartGame;
            dialoguePanel.Show();
        }
        else
        {
            StartGame();
        }
        
        status.CompleteMinigame(SceneType.MiniGame);
        status.VisitMinigame(SceneType.MiniGame);
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
            _audioSource.Play();
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
        gameOverPanel.Show();

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

    public void ReloadScene()
    {
        sceneTransitionManager.TransitionToScene(SceneType.MiniGame);
    }
}
