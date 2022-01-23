using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// Skript zum Ein-/Ausblenden der erkannten Flächen auf denen die Windkraftanlagen gespawnt
// werden 

[RequireComponent(typeof(ARPlaneManager))]
public class PlaneHiding : MonoBehaviour
{
    private ARPlaneManager planeManager;
    public Text toggleButtonText; 

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        //Textfeld des Toggels bei Starten auf "Erkannte Flächen ausblenden" setzen
        toggleButtonText.text = "Erkannte Flächen ausblenden"; 
    }

    public void TogglePlaneDetection()
    {
        planeManager.enabled = !planeManager.enabled;
        string toggleButtonMessage = "";

        if (planeManager.enabled)
        {
            toggleButtonMessage = "Erkannte Flächen ausblenden";
            SetAllPlanesActive(true);
        }

        else
        {
            toggleButtonMessage = "Erkannte Flächen einblenden";
            SetAllPlanesActive(false);
        }

        toggleButtonText.text = toggleButtonMessage;
    }

    private void SetAllPlanesActive(bool value) 
    {
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}
