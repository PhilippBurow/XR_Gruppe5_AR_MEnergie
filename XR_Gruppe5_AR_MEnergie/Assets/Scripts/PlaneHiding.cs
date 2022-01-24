using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// Skript zum Ein-/Ausblenden der erkannten Fl?chen auf denen die Windkraftanlagen gespawnt
// werden 

[RequireComponent(typeof(ARPlaneManager))]
public class PlaneHiding : MonoBehaviour
{
    private ARPlaneManager planeManager;
    public Text toggleButtonText; 

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        //Textfeld des Toggels bei Starten auf "Erkannte Fl?chen ausblenden" setzen
        toggleButtonText.text = "Erkannte Ebenen ausblenden"; 
    }

    public void TogglePlaneDetection()
    {
        planeManager.enabled = !planeManager.enabled;
        string toggleButtonMessage = "";

        if (planeManager.enabled)
        {
            toggleButtonMessage = "Erkannte Ebenen ausblenden";
            SetAllPlanesActive(true);
        }

        else
        {
            toggleButtonMessage = "Erkannte Ebenen einblenden";
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
