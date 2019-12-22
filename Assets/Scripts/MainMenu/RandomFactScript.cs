using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class RandomFactScript : MonoBehaviour
{
    // Necessary things. (Private Fields
    private Timer _randFactTimer;
    private string[] _randFacts = new string[]
    {
        "This game was inspired by VVVVVV.",
        "Bananas always grow towards the sun.",
        "You are wasting your time reading these facts",
        "Typing in 'takemetothepizza' won't trigger anything...",
        "Why jump when you can flip the gravity?",
        "Powered by Portals since... idk when.",
        "Developer ran out of facts to display. Enjoy this waste of space."
    };
    private Random _rand;
    private string _fact;
    
    // Necessary Things. (Unity Fields)
    [Tooltip("Random Fact Text Box here")]
    public Text RandomFactText;

    // Start is called before the first frame update
    void Start()
    {
        RandomFactText = GetComponent<Text>();
        _rand = new Random();
        _randFactTimer = new Timer();
        SetupTimer();
        _fact = "Welcome to Infinicube!";
    }

    // Update is called once per frame
    void Update()
    {
        RandomFactText.text = _fact; // Write fact into the TextBox
    }
    
    // Custom methods
    private void SetupTimer()
    {
        var startTime = DateTime.Now;
        _randFactTimer.Interval = 15000; // 15 seconds
        _randFactTimer.Elapsed += RandFactTimerOnElapsed;
        _randFactTimer.AutoReset = true;
        _randFactTimer.Enabled = true;
        Debug.Log($"[Infinicube.MainMenu.RandFactTimer] Timer has been started at {startTime}");
    }

    private void RandFactTimerOnElapsed(object sender, ElapsedEventArgs e)
    {
        var changeTime = e.SignalTime;
        var randIdx = _rand.Next(_randFacts.Length); // Get next Status to display
        var fact = _randFacts[randIdx]; // Assign chosen fact.
        _fact = fact; // More Assignments
        Debug.Log($"[Infinicube.MainMenu.RandFactTimer] Fact changed at {changeTime}\n" +
                   $"[Infinicube.MainMenu.RandFactTimer] Current fact: {fact}");
    }
}
