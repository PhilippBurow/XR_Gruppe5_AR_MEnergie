using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

// Script to show/hide the detected planes on which the wind turbines can be spawned

[RequireComponent(typeof(ARPlaneManager))]      // The RequireComponent attribute automatically adds required components as dependencies
public class PlaneHiding : MonoBehaviour
{
    private ARPlaneManager planeManager;
    public Text toggleButtonText;               // text field which should be changed 

    private void Awake() 
    {
        planeManager = GetComponent<ARPlaneManager>();          // reference between Variable "planeManager" and AR-Planes
        toggleButtonText.text = "Erkannte Ebenen ausblenden";   // Set the text field of the toggle to "Erkannte Ebenen ausblenden" at awake
    }

    public void TogglePlaneDetection()                          // active when the button is pressed
    {
        planeManager.enabled = !planeManager.enabled;           // disable planeManager at awake 
        string toggleButtonMessage = "";                        // new string for the changing text in the text field 

        if (planeManager.enabled)                               // If planes are visible
        {
            toggleButtonMessage = "Erkannte Ebenen ausblenden"; // => Button text = disable
            SetAllPlanesActive(true);                           // => show all detected plaes
        }
            
        else                                                    // If planes are not visible 
        {
            toggleButtonMessage = "Erkannte Ebenen einblenden"; // => Button text = disable
            SetAllPlanesActive(false);                          // => hide all detected planes
        }

        toggleButtonText.text = toggleButtonMessage;            // toggleButtonMessage to text field of the toggle
    }

    private void SetAllPlanesActive(bool value)                 // Sets all trackables (in this case planes) true or false
    {                                                           
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}
