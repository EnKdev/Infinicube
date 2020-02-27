using System;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class RandomFactScript : MonoBehaviour
{
    // Benötigte Felder
    private string[] _randFacts = new string[]
    {
        "Dieses Spiel wurde von Terry Cavanagh's VVVVVV inspiriert.",
        "Bananen wachsen immer zur Sonne entgegen.",
        "Du verschwendest deine Zeit mit dem Lesen sinnloser Fakten",
        "'takemetothepizza' wird nichts bringen. Schreib es also nicht. (Ernsthaft jetzt.)",
        "Wieso springen wenn man die Gravitation ändern kann?",
        "Powered by Portals seit... öhm... keine Ahnung",
        "Entwickler fiel kein weiterer Random Fact mehr ein. Genieße die Platzverschwendung hier",
        "Rückwärtsfallend seit 2020!",
        "#Infinicube",
        "Obamium",
        "Ein Corona auf die Devs.",
        "Limetten hier!"
    };
    private Random _rand;
    private string _fact;

    public static Timer randFactTimer;
    
    [Tooltip("Random Fact Text Box here")]
    public Text RandomFactText;

    // Start is called before the first frame update
    void Start()
    {
        RandomFactText = GetComponent<Text>();
        _rand = new Random();
        randFactTimer = new Timer();
        SetupTimer();
        _fact = "Willkommen zu Infinicube!";
    }

    // Update is called once per frame
    void Update()
    {
        RandomFactText.text = _fact;
    }
    
    // Custom methods
    private void SetupTimer()
    {
        var startTime = DateTime.Now;
        randFactTimer.Interval = 5000; // 5 seconds
        randFactTimer.Elapsed += RandFactTimerOnElapsed;
        randFactTimer.AutoReset = true;
        randFactTimer.Enabled = true;
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
