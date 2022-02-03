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
    public Camera ARCamera;         // connection to AR Camera
    private List<RaycastResult> raycastResults = new List<RaycastResult>();      
    public Material myMaterial;     // connection to base material "M_Distance"

    // enable/disable spawning of wind turbine's depending on distance between
    // spawned Windturbine and WindturbinePlacementIndicator

    // function to check if two game object^Collider collide/enter
    private void OnTriggerEnter(Collider other)       
    {
        // compare tags of colliding game objects. "Player" is tagged to
        // windturbine prefab and Placementindicator
        if (other.CompareTag("Player"))              
        {
            // change variable "Distance" to false
            Distance = false;                         
                Debug.Log("Distance = False");              
        }
     }

    private void OnTriggerStay(Collider other)
    {
        // compare tags of game objects. "Player" is tagged to windturbine
        // prefab and Placementindicator
        if (other.CompareTag("Player"))              
        {
            // change variable "Distance" to false
            Distance = false;                        
            Debug.Log("Distance = False");
        }
    }

        private void OnTriggerExit(Collider other)
    {
        // compare tags of game objects. "Player" is tagged to windturbine
        // prefab and Placementindicator
        if (other.CompareTag("Player"))              
        {
            // change variable "Distance" to false
            Distance = true;                         
            Debug.Log("Distance = True");
        }
    }

    // Prevents touches on UI elements from being detected as touch input
    // check if touch input on UI element
    private bool isPointerOverUI(Vector2 fingerPosition)                                     
    {
        PointerEventData eventDataPosition = new PointerEventData(EventSystem.current);      
        eventDataPosition.position = fingerPosition;                                        
        EventSystem.current.RaycastAll(eventDataPosition, raycastResults);
        // if greater than zero, that means we hit a UI element
        return raycastResults.Count > 0;                                                    
    }

    void Start()
    {
        // search the ARRaycastManager in the hirarchy
        rayManager = FindObjectOfType<ARRaycastManager>();
        // searches the child of the GameObject on which the script is located
        visual = transform.GetChild(0).gameObject;
        // hide placement indicator at app start (until plane is detected)
        visual.SetActive(false);                                                            
    }

     void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        // check if planes (trackableType = Planes) are hit in the middle of the screen
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits,          
            TrackableType.Planes);

        // Die Position/Rotation wird dauerhaft (Update) aktuell gehalten
        // when hits (a plane is hit) > 0, the position and the rotation for the wind
        // turbine to be spawned is permanently updated
        if (hits.Count > 0)                                                                 
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            // makes the PlacementIndicator(visual) visible when a plane is hit
            if (!visual.activeInHierarchy)                                                  
                visual.SetActive(true);
        }

        // if touch input, distance is big enough and delete toggle is disabled?
        if ((((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)       
            && (Distance == true) && (!DeleteToggle.isOn == true))))
        {
            // control over DebugLog
            Debug.Log("Mouse down");

            // determine position where screen is pressed
            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);                       
            Debug.Log(ray);

            // do not spawn wind turbine if touch input over UI element 
            if (isPointerOverUI(Input.mousePosition))                                       
            {
                Debug.Log("Do nothing!");
            }

            else
            {
                // spawn the GameObject at the same place where the placement indicator is located
                GameObject prefab_gameobject = Instantiate(ObjectToPlace,                   
                    transform.position, transform.rotation);
            }
        }

        // reset variables when out of delete mode

        if (DeleteToggle.isOn == true)  
        {
            // hides PlacementIndictor when in delete-mode
            visual.SetActive(false);                                                        

            if ((DeleteToggle.isOn == false) && (!visual.activeInHierarchy))                
        
            visual.SetActive(false);            // show PlacementIndicator
            myMaterial.color = Color.green;     // sets the material of the wind turbine's base green
            Distance = true;                    // sets the variable distance to true
        }   
    }
}
