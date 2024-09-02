using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI speakerText;
    private int _currentDialogue = 0;
    [SerializeField] private Image _stars, _plains, _oceans, _desert, _grow;
    private Image currBg;
    
    string[] dialogue = new string[] {
            "You got that new planet assignment right?",
            "Urth? Erath? ...whatever something like that.",
            "Anyway, you're still new at making planets, but this should be an easy one!",
            "Some plains, oceans, forests, deserts, you know the drill.",
            "Good luck!",
            "So you began your journey to create the Earth."
    };

    void Start()
    {
        speakerText.text = "ARCHITECT - D25";
        text.text = "Hey, congrats!";
        currBg = _stars;
        _plains.gameObject.SetActive(false);
        _oceans.gameObject.SetActive(false);
        _desert.gameObject.SetActive(false);
        _grow.gameObject.SetActive(false);
    }

    public void NextLine()
    {
        if (_currentDialogue < dialogue.Length)
        {
            Debug.Log("here");
            text.text = dialogue[_currentDialogue];
            _currentDialogue++;
            if (_currentDialogue == dialogue.Length)
            {
                speakerText.text = "Narrator";
            }
        }
        else if (currBg == _stars) 
        {
            // Next part is to set current image to inactive, and set next to active.
            text.color = Color.white;
            text.text = "You created grasslands, full of life and prosperity.";
            _stars.gameObject.SetActive(false);
            _plains.gameObject.SetActive(true);
            currBg = _plains;
        }
        else if (currBg == _plains)
        {
            text.text = "You created vast oceans, containing the depths of the unknown.";
            _plains.gameObject.SetActive(false);
            _oceans.gameObject.SetActive(true);
            currBg = _oceans;
        }
        else if (currBg == _oceans)
        {
            text.text = "Now you set your sights on creating the deserts.";
            _oceans.gameObject.SetActive(false);
            _desert.gameObject.SetActive(true);
            currBg = _desert;
        }
        else if (currBg == _desert)
        {
            text.text = "The problem is...";
            currBg = _grow;
        }
        else if (currBg == _grow)
        {
            _desert.gameObject.SetActive(false);
            _grow.gameObject.SetActive(true);
            text.text = "IT WON'T STOP GROWING!!!";
            currBg = null;
        }
        else
        {
            SceneManager.LoadScene("MainGame");
        }

    }

}
