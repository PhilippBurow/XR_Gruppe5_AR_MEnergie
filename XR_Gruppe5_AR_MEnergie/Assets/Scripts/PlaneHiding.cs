using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

// script to show/hide the detected planes on which the wind turbines can be spawned

// the RequireComponent attribute automatically adds required components as dependencies
[RequireComponent(typeof(ARPlaneManager))]      

public class PlaneHiding : MonoBehaviour
{
    private ARPlaneManager planeManager;
    public Text toggleButtonText;             // text field which should be changed 

    private void Awake() 
    {
        // reference between Variable "planeManager" and AR-Planes
        planeManager = GetComponent<ARPlaneManager>();
        // set the text field of the toggle to "Erkannte Ebenen ausblenden" at awake
        toggleButtonText.text = "Erkannte Ebenen ausblenden";   
    }

    // active when the button is pressed
    public void TogglePlaneDetection()                          
    {
        // disable planeManager at awake
        planeManager.enabled = !planeManager.enabled;
        // new string for the changing text in the text field
        string toggleButtonMessage = "";

        // if planes are visible
        if (planeManager.enabled)                               
        {
            // => button text = disable
            toggleButtonMessage = "Erkannte Ebenen ausblenden";
            // => show all detected planes
            SetAllPlanesActive(true);                           
        }
            
        else                                                     
        {
            // if planes are not visible
            // => button text = disable
            toggleButtonMessage = "Erkannte Ebenen einblenden";
            // => hide all detected planes
            SetAllPlanesActive(false);                          
        }

        // toggleButtonMessage to text field of the toggle
        toggleButtonText.text = toggleButtonMessage;            
    }

    // sets all trackables (in this case planes) true or false
    private void SetAllPlanesActive(bool value)                 
    {                                                           
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}
