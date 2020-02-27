using UnityEngine;

/// <summary>
/// Der Player Controller, der dafür sorgt, dass wir unseren Player steuern können.
/// Erstellt: 27.02.2020
/// Autoren: Niklas Zeeb, Nicholas Hesse
/// Revision: 4
/// </summary>

public class PlayerController : MonoBehaviour
{
    bool druecken = false;
    bool amBoden = false;
    bool amDach = false;
    float y = 0;                          //Rauf und Runter
    float x = 0;                          //Links und Rechts
    SpriteRenderer spriteRenderer;
    bool Antigravity = false;
    [SerializeField]
    Transform BodenCheck;               //für amBoden;
    [SerializeField]                    
    Transform DachCheck;                //für amDach;
    [SerializeField]
    float Geschwindigkeit = 1;
    [SerializeField]
    float Schwerkraft = 1;

    private Rigidbody2D rb2d;

    // Für Checkpoints
    public delegate void DeathDelegate();
    public event DeathDelegate onDeath;

    void Death()
    {
        onDeath.Invoke();
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    
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
    
    void QuitGame()
    {
            Application.Quit();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Hazard")
        {
            Antigravity = false;
            spriteRenderer.flipY = Antigravity;
            rb2d.transform.position = Checkpoint.GetActiveCheckpointPosition();
        }
    }
}
