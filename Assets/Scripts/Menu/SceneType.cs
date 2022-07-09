using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneType
{
    MainMenu,
    MiniGame,
    CookingMinigame,
    RocketMinigame,
}

static class SceneTypeExtensions
{
    public static string GetSceneName(this SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.MainMenu:
                return "Menu";
            case SceneType.MiniGame:
                return "Minigame";
            case SceneType.CookingMinigame:
                return "CookingMinigame";
            case SceneType.RocketMinigame:
                return "RocketMinigame";
            default:
                return null;
        }
    }
}
