using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PizzaScript : MonoBehaviour
{
    // Necessary Things. (Private fields)
    private string _myText;
    private int _argProgress;
    
    // Necessary Things. (Unity Fields)
    [Tooltip("Title Text Box here")] public Text TitleTextBox;
    [Tooltip("Speaker Text Box here")] public Text SpeakTextBox;
    [Tooltip("Secret Codes here!")] public string[] SecretCodes;
    [Tooltip("Input Field here!")] public InputField SecretInput;
    
    // Start is called before the first frame update
    void Start()
    {
        _myText = "";
        _argProgress = 0;
        SecretInput.interactable = true;
        SpeakTextBox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        SecretDetected();
    }

    // Update this and SecretCodes + Materials whenever you add something new!
    private void SecretDetected()
    {
        _myText = SecretInput.text;

        if (SecretCodes.Contains(_myText))
        {
            if (_myText == "takemetothepizza")
                TitleTextBox.color = Color.yellow;

            if (_myText == "hello?" && _argProgress == 0)
            {
                SpeakTextBox.text = "Ah yes, Hello there! 't was getting quite lonely in here...";
                _argProgress = 1;
                SecretInput.text = "";
            }

            if (_myText == "what is this?" && _argProgress == 1)
            {
                SpeakTextBox.text =
                    "Well, it can be what you think it would be. I define it as some sort of black void though.";
                _argProgress = 2;
                SecretInput.text = "";
            }

            if (_myText == "uh-huh" && _argProgress == 2)
            {
                SpeakTextBox.text =
                    "You seem not surprised, eh? And what if I tell you that someone is standing right behind you?";
                _argProgress = 3;
                SecretInput.text = "";
            }

            if (_myText == "well ok then." && _argProgress == 3)
            {
                SpeakTextBox.text = "...Fine, you're one party pooper.";
                _argProgress = 4;
                SecretInput.text = "";
            }

            if (_myText == "..." && _argProgress == 4)
            {
                SpeakTextBox.text = "...ugh, ok, you know what? Fine. I'll go. See you never...";
                SecretInput.text = "fucktard.";
                _argProgress = 0;
            }
        }
        else
            TitleTextBox.color = Color.white;
    }
}
