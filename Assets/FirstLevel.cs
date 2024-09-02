using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstLevel : MonoBehaviour
{
    [SerializeField] public GridController gridController;
    [SerializeField] private TextMeshProUGUI text;

    private int _currentDialogue = 0;
    private string[] dialogue = new string[] {
            "Try hovering over the desert tiles.",
            "This is a grass tile...which does NOT belong in a desert!",
            "Click on it to get rid of it!",
    };

    void Start()
    {
        text.text = "This is your desert.";
    }

    public void InitTutorial()
    {
        if (_currentDialogue == 0)
        {
            text.text = "Try hovering over the desert tiles.";
            gridController.StartTutorialLevel();
            _currentDialogue++;
        }
        else if (_currentDialogue < dialogue.Length)
        {
            if(_currentDialogue == 1)
            {
                gridController.TransformMiddle();
            }
            if (_currentDialogue == 2)
            {

            }
            text.text = dialogue[_currentDialogue];
            _currentDialogue++; 
        }
    }
}
