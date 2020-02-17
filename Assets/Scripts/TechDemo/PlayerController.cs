using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Der Player Controller, der dafür sorgt, dass wir unseren Player steuern können.
/// Erstellt: 20.01.2020 - 16:33 Uhr
/// Ersteller: Niklas Zeeb
/// Revision: 2
/// </summary>

public class PlayerController : MonoBehaviour //---------------INFINICUBE
{
    bool druecken = false;              //private bool gedrueckt;
    bool amBoden = false;
    bool amDach = false;
    float y = 0;                          //Rauf und Runter
    float x = 0;                          //Links und Rechts
    SpriteRenderer spriteRenderer;
    bool Antigravity = false;           //private bool flipped;
    [SerializeField]
    Transform BodenCheck;               //für amBoden;
    [SerializeField]                    
    Transform DachCheck;                //für amDach;
    [SerializeField]
    float Geschwindigkeit = 1;
    [SerializeField]
    float Schwerkraft = 1;


    //    // Benötigte Felder: <------------------------Are you sure about that?
    //    private Rigidbody2D rb2d;

    //Nicholas' Start
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    //Nicklas' Start
    //    void Start()
    //    {
    //        // Speichere eine Referenz zu einem Rigidbody2D Objekt damit wir später im Code
    //        // darauf zugreifen können
    //        rb2d = GetComponent<Rigidbody2D>();

    //        rb2d.freezeRotation = true; // Verhindere irgendwelche Rotationen
    //        flipped = false; // Mid-Air Gravitationsänderungen sollen hiermit verhindert werden
    //        amBoden = true;
    //        gedrueckt = false;
    //    }

    //Nicholas' Programm
    private void FixedUpdate()
    {
        //aktuallisiert ob der spieler am boden ist.
        amBoden = Physics2D.Linecast(transform.position, BodenCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        amDach = Physics2D.Linecast(transform.position, DachCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //Schwerkrafts Definition Anfang
        if (amBoden && Antigravity == false)
        {
            y = 0 * Schwerkraft;
        }
        else if (Antigravity == false)
        {
            y = -1 * Schwerkraft;
        }
        if (amDach && Antigravity == true)
        {
            y = 0 * Schwerkraft;
        }
        else if (Antigravity == true)
        {
            y = 1 * Schwerkraft;
        }
        //Schwerkrafts Definition Ende

        //Abfrage zum laufen
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            x = 1 * Geschwindigkeit;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            x = -1 * Geschwindigkeit;
            spriteRenderer.flipX = true;
        }
        else
        {
            x = 0;
        }

        //Flippen
        if ((Input.GetKey("w") || Input.GetKey("up") || Input.GetKeyDown(KeyCode.Space)) && !druecken && (amDach || amBoden))
        { //Erst fragt er ab welche taste gedrückt wird, dann ob er es schon vorher drückte und dann ob er am Boden/Dach ist
            Antigravity = !Antigravity;
            spriteRenderer.flipY = Antigravity;
            druecken = !druecken;
        }
        else if (!(Input.GetKey("w") || Input.GetKey("up") || Input.GetKeyDown(KeyCode.Space)))
        {
            druecken = !druecken;
        }
        transform.Translate(new Vector3(x * Time.deltaTime, y * Time.deltaTime, 0)); //Geschwindigkeit an den Achsen X,Y,Z in dieser reihenfolge

        //von Niklas lassen wir drine
        if (Input.GetKeyDown(KeyCode.Escape))
                QuitGame();
    }
    //Nicklas' HauptProgramm
    //    private void Update()
    //    {
    //        // Speichere den momentanen Horizontalen Input in einem Float-Attribut names horizontal
    //        float horizontal = Input.GetAxis("Horizontal");

    //        // Initialisiere ein neues Objekt vom Typ Vector2 mit dem wir
    //        // ein paar Bewegungswerte initialisieren
    //        Vector3 tempVect = new Vector3(horizontal, 0, 0);

    //        // Berechnungen für die Bewegungen usw...
    //        tempVect = tempVect.normalized * geschwindigkeit * Time.deltaTime;

    //        rb2d.MovePosition(rb2d.transform.position + tempVect);

    //        // Wenn der Spieler die Taste S oder die Leertaste drückt, soll unser Sprite geflippt werden.
    //        // Und die Gravitation soll umgekehrt werden
    //        if (Input.GetKeyDown(KeyCode.S) && !flipped || Input.GetKeyDown(KeyCode.Space) && amBoden && !flipped)
    //        {
    //            SpriteFlip(); // Flippe den Sprite
    //            rb2d.gravityScale = -5 * 3 * Time.deltaTime; // Kehre die Gravitation um
    //            flipped = !flipped; // Boolcheck für Später
    //            gedrueckt = !gedrueckt;
    //        }
    //        else if (Input.GetKeyDown(KeyCode.S) && flipped || Input.GetKeyDown(KeyCode.Space) && amBoden && flipped)
    //        {
    //            SpriteFlip(); // Flippe den Sprite
    //            rb2d.gravityScale = 5 * 3 * Time.deltaTime; // Kehre die Gravitation um
    //            flipped = !flipped; // Boolcheck für Später
    //            gedrueckt = !gedrueckt;
    //        }
    //        else if (!(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space)))
    //        {
    //            gedrueckt = !gedrueckt;
    //        }

    //        
    //    }

    //    // Diese Methode ist wichtig damit wir unseren Charakter einmal flippen können
    //    void SpriteFlip()
    //    {
    //        Vector3 playerScale = transform.localScale;
    //        playerScale.y *= -1;
    //        transform.localScale = playerScale;
    //    }



    //würde ich drin lassen
    //---------------------------------------------
    // Damit das Spiel auch beendbar ist. 
    void QuitGame()
    {
            Application.Quit();
    }
}
