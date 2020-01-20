using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Der Hazard Controller, der dafür sorgt, dass der Player sterben kann wenn er mit einem Gegner oder Worldhazard
/// in berührung kommt.
/// Erstellt: 20.01.2020 - 17:35 Uhr
/// Ersteller: Niklas Zeeb
/// Revision: 2
/// </summary>

public class HazardController : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(other.gameObject);

        ResetLevel();
    }

    private void ResetLevel()
    {
        SceneManager.LoadSceneAsync("TechDemo");
    }
}
