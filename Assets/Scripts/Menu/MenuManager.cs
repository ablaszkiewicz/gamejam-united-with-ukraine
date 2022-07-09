using System.Collections;
using System.Collections.Generic;
using Menu;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private MinigamesStatus minigamesStatus;
    
    public MinigamesStatus MinigamesStatus
    {
        get { return minigamesStatus; }
    }
}
