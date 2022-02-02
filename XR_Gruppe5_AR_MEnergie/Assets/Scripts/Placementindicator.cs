using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Script for
// - prevent spawning wind turbines if they are too close to each other
// - prevents touches on UI elements from being detected as touch input
// - placementIndicator in center of screen & on detected planes
// - reset variables when out of delete mode

public class Placementindicator : MonoBehaviour
{
    private ARRaycastManager rayManager;                                        
    private GameObject visual;                                                  
    public GameObject ObjectToPlace;                                            
    private bool Distance = true;                                               
    public Toggle DeleteToggle;                                                  
    public Camera ARCamera;                                                     // connection to AR Camera
    private List<RaycastResult> raycastResults = new List<RaycastResult>();      
    public Material myMaterial;                                                 // connection to base material "M_Distance"

    // enable/disable spawning of wind turbine's depending on distance between spawned Windturbine and WindturbinePlacementIndicator

    private void OnTriggerEnter(Collider other)      // function to check if two game objects collide
    {   
        if (other.CompareTag("Player"))              // compare tags of colliding game objects. "Player" is tagged to windturbine prefab and Placementindicator
        {
            Distance = false;                        // change variable "Distance" to false 
                Debug.Log("Distance = False");              
        }
     }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))              // compare tags of game objects. "Player" is tagged to windturbine prefab and Placementindicator
        {
            Distance = false;                        // change variable "Distance" to false
            Debug.Log("Distance = False");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))              // compare tags of game objects. "Player" is tagged to windturbine prefab and Placementindicator
        {
            Distance = true;                         // change variable "Distance" to false
            Debug.Log("Distance = True");
        }
    }

    // Prevents touches on UI elements from being detected as touch input
    private bool isPointerOverUI(Vector2 fingerPosition)                                
    {
        PointerEventData eventDataPosition = new PointerEventData(EventSystem.current);
        eventDataPosition.position = fingerPosition;
        EventSystem.current.RaycastAll(eventDataPosition, raycastResults);
        return raycastResults.Count > 0;                                                    //if greater than zero, that means we hit a UI element
    }

    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();                                  // search the ARRaycastManager in the hirarchy
        visual = transform.GetChild(0).gameObject;                                          // searches the child of the GameObject on which the script is located
        visual.SetActive(false);                                                            // hide placement indicator at app start (until plane is detected)
    }

     void Update()
    {
        // "Strahl" dauerhaft (Update) aus der Bildschirmmitte "schieﬂen". Wenn dieser ein
        // "Trackable", in unserem Fall eine Plane trifft wird diese Position/Rotation
        // gespeichert.
        // Bezugsposition ist in diesem Fall die AR Camera
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        // Die Position/Rotation wird dauerhaft (Update) aktuell gehalten.
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy)                                                  // makes the PlacementIndicator visible when a plane is hit
                visual.SetActive(true);
        }

        if ((((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)       // 
            && (Distance == true) && (!DeleteToggle.isOn == true))))
        {
            Debug.Log("Mouse down");                                                        // control over DebugLog

            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);                       // determine position where screen is pressed
            Debug.Log(ray);

            if (isPointerOverUI(Input.mousePosition))
            {
                Debug.Log("Do nothing!");
            }

            else
            {
                GameObject prefab_gameobject = Instantiate(ObjectToPlace,                   // Spawn the GameObject at the same place where the placement indicator is located
                    transform.position, transform.rotation);
            }
        }

        // reset variables when out of delete mode

        if (DeleteToggle.isOn == true)  
        {
            visual.SetActive(false);                                                        // Hides PlacementIndictor when in delete-mode

            if ((DeleteToggle.isOn == false) && (!visual.activeInHierarchy))                
        
            visual.SetActive(false);                                                        // show PlacementIndicator
            myMaterial.color = Color.green;                                                 // sets the material of the wind turbine's base to green
            Distance = true;                                                                // sets the variable distance to true
        }   
    }
}
