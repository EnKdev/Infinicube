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

public class PlayerController : MonoBehaviour
{
    // Benötigte Felder:
    public float geschwindigkeit;

    private Rigidbody2D rb2d;

    private bool flipped;
    private bool amBoden;

    // Start is called before the first frame update
    void Start()
    {
        // Speichere eine Referenz zu einem Rigidbody2D Objekt damit wir später im Code
        // darauf zugreifen können
        rb2d = GetComponent<Rigidbody2D>();
        
        rb2d.freezeRotation = true; // Verhindere irgendwelche Rotationen
        flipped = false; // Mid-Air Gravitationsänderungen sollen hiermit verhindert werden
        amBoden = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Speichere den momentanen Horizontalen Input in einem Float-Attribut names horizontal
        float horizontal = Input.GetAxis("Horizontal");

        // Initialisiere ein neues Objekt vom Typ Vector2 mit dem wir
        // ein paar Bewegungswerte initialisieren
        Vector3 tempVect = new Vector3(horizontal, 0, 0);
        
        // Berechnungen für die Bewegungen usw...
        tempVect = tempVect.normalized * geschwindigkeit * Time.deltaTime;

        rb2d.MovePosition(rb2d.transform.position + tempVect);

        // Wenn der Spieler die Taste S oder die Leertaste drückt, soll unser Sprite geflippt werden.
        // Und die Gravitation soll umgekehrt werden
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space) && amBoden)
        {
            SpriteFlip(); // Flippe den Sprite
            rb2d.gravityScale *= -1; // Kehre die Gravitation um
            flipped = !flipped; // Boolcheck für Später
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            QuitGame();
    }

    // Diese Methode ist wichtig damit wir unseren Charakter einmal flippen können
    void SpriteFlip()
    {
        Vector3 playerScale = transform.localScale;
        playerScale.y *= -1;
        transform.localScale = playerScale;
    }

    // Damit das Spiel auch beendbar ist.
    void QuitGame()
    {
        Application.Quit();
    }
}
