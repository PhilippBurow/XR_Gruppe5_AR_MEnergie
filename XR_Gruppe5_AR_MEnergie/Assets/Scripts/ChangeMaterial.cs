using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour

{
    public Toggle DeleteToggle;

    [SerializeField] private Material myMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) // Auf dem GameObject welches gemeint ist muss der Tag "Player liegen" Der Collider muss "Is Triggert" sein.
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
