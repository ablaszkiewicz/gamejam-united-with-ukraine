using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PositionState lastPositionState = PositionState.CENTER;
    
    [SerializeField]
    private PositionState positionState = PositionState.CENTER;

    private RocketMinigameManager rocketMinigameManager;
    
    private const float moveOffset = 3f;
    private float startY;

    private void Awake()
    {
        rocketMinigameManager = FindObjectOfType<RocketMinigameManager>();
        startY = transform.position.y;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StateToLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StateToRight();
        }
        
        UpdateRocketPosition();
    }

    private void StateToLeft()
    {
        if (positionState == PositionState.RIGHT)
        {
            positionState = PositionState.CENTER;
            FindObjectOfType<RocketMinigameSoundPlayer>().PlayDashSound();
        }
        else if (positionState == PositionState.CENTER)
        {
            positionState = PositionState.LEFT;
            FindObjectOfType<RocketMinigameSoundPlayer>().PlayDashSound();
        }
    }

    private void StateToRight()
    {
        if (positionState == PositionState.LEFT)
        {
            positionState = PositionState.CENTER;
            FindObjectOfType<RocketMinigameSoundPlayer>().PlayDashSound();

        }
        else if (positionState == PositionState.CENTER)
        {
            positionState = PositionState.RIGHT;
            FindObjectOfType<RocketMinigameSoundPlayer>().PlayDashSound();
        }
    }

    private void UpdateRocketPosition()
    {
        if (lastPositionState != positionState)
        {
            lastPositionState = positionState;

            transform.DOKill();
            transform.DOMove(GetVectorFromState(), 0.2f).SetEase(Ease.OutCubic);
        }
    }

    private Vector3 GetVectorFromState()
    {
        switch (positionState)
        {
            case PositionState.LEFT:
                return new Vector3(-moveOffset, startY, 0);
            case PositionState.CENTER:
                return new Vector3(0, startY, 0);
            case PositionState.RIGHT:
                return new Vector3(moveOffset, startY, 0);
            default:
                return Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            rocketMinigameManager.StopGame();
            FindObjectOfType<RocketMinigameSoundPlayer>().PlayCrashSound();
        }
        
        if (col.gameObject.CompareTag("WinChecker"))
        {
            rocketMinigameManager.WinGame();
        }
    }
}

enum PositionState
{
    LEFT,
    CENTER,
    RIGHT
}