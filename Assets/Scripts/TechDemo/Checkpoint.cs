using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.U2D;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Ist der Checkpoint aktiv?
    public bool Aktiv = false;

    // Sprites.
    public Sprite NichtGetriggered;
    public Sprite Getriggered;

    // Liste alle Checkpoint Objekte in der Szene auf
    public static GameObject[] CheckpointList;
    private GameObject CurrentCheckpoint;

    public static Vector3 GetActiveCheckpointPosition()
    {
        // Falls der Spieler stirbt ohne einen aktiven Checkpoint, dann geben wir eine Standardposition zurück
        Vector3 result = new Vector3((float)-8.203, (float)-2.03, (float)-2.44);

        if (CheckpointList != null)
        {
            foreach (GameObject cp in CheckpointList)
            {
                // Suche nach dem aktivierten Checkpoint um seine Position zu bekommen
                if (cp.GetComponent<Checkpoint>().Aktiv)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }

    // Aktiviere den Checkpoint
    private void ActivateCheckpoint()
    {
        // Als erstes deaktivieren wir alle Checkpoints in der Szene
        foreach (GameObject cp in CheckpointList)
        {
            cp.GetComponent<Checkpoint>().Aktiv = false;
            cp.GetComponent<SpriteRenderer>().sprite = NichtGetriggered;
        }
        
        // Danach aktivieren wir den Checkpoint.
        Aktiv = true;
        CurrentCheckpoint.GetComponent<SpriteRenderer>().sprite = Getriggered;
    }

    private void Start()
    {
        CurrentCheckpoint = gameObject;
        CheckpointList = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            ActivateCheckpoint();
    }
}
