using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void VisitMinigame(SceneType sceneType)
        {
            minigamesStatuses.Where(status => status.sceneType == sceneType).FirstOrDefault().isVisited = true;
        }
        
        public bool GetVisitStatus(SceneType sceneType)
        {
            return minigamesStatuses.Where(status => status.sceneType == sceneType).FirstOrDefault().isVisited;
        }
    }

    [Serializable]
    public class MinigameStatus
    {
        public SceneType sceneType;
        public bool isFinished;
        public bool isVisited;
    }
}