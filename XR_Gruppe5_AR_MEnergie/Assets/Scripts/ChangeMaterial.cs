using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Skript um das Material, welches die Farbe des Fußes des WindturbinenIndicators einfärbt bzw. die Farbe zwischen grün & rot wechselt

public class ChangeMaterial : MonoBehaviour

{
    public Toggle DeleteToggle; // Schafft Verbindung zum Toggle 

    public Material myMaterial; // Schafft die Verbindung zum Material 

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) // Auf dem GameObject welches gemeint ist muss der Tag "Player liegen" Der Collider muss "Is Triggert" sein.
        {
            myMaterial.color = Color.red; 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            myMaterial.color = Color.red;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myMaterial.color = Color.green;
        }
    }
}
