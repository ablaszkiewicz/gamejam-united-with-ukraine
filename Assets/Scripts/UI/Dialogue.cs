using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogueScriptableObject", order = 1)]
public class Dialogue : ScriptableObject
{
    [SerializeField] private List<SingleDialogue> dialogues;
    
    public List<SingleDialogue> GetDialogues()
    {
        return new List<SingleDialogue>(dialogues);
    }
}


[Serializable]
public class SingleDialogue
{
    public string name;
    public string sentence;
    public string buttonText;
    public Sprite image;
}
