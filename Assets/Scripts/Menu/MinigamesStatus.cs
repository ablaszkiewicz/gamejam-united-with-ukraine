using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Menu
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MinigamesStatusScriptableObject", order = 1)]
    public class MinigamesStatus : ScriptableObject
    {
        public List<MinigameStatus> minigamesStatuses;

        public bool GetStatusForScene(SceneType sceneType)
        {
            return minigamesStatuses.Where(status => status.sceneType == sceneType).FirstOrDefault().isFinished;
        }

        public void CompleteMinigame(SceneType sceneType)
        {
            minigamesStatuses.Where(status => status.sceneType == sceneType).FirstOrDefault().isFinished = true;
        }
    }

    [Serializable]
    public class MinigameStatus
    {
        public SceneType sceneType;
        public bool isFinished;
    }
}