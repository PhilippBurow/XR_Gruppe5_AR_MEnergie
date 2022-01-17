using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Placementindicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;
    public GameObject ObjectToPlace;
    private bool Distance = true;
    public Toggle DeleteToggle;
    public Camera ARCamera;

    private List<RaycastResult> raycastResults = new List<RaycastResult>();

    // Wenn im Collider vom Prefab WindTurbine (Tag "Player") kann nicht gespawnt werden -> Kreis ist Rot.
    private void OnTriggerEnter(Collider other)
     {   
        if (other.CompareTag("Player"))
        {
            Distance = false;
                Debug.Log("Distance = False");
        }
     }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Distance = false;
                Debug.Log("Distance = False");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Distance = true;
                Debug.Log("Distance = True");
        }
    }
    private bool isPointerOverUI(Vector2 fingerPosition)
    {
        PointerEventData eventDataPosition = new PointerEventData(EventSystem.current);
        eventDataPosition.position = fingerPosition;
        EventSystem.current.RaycastAll(eventDataPosition, raycastResults);
        return raycastResults.Count > 0; //if greater than zero, that means we hit a UI Element
    }

    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>(); // Sucht den ARRaycastManager im Project
        visual = transform.GetChild(0).gameObject; // sucht das Child, also das GameObject auf dem das Skript liegt
       

        // Placementindicator bei App-Start erstmal ausblenden (bis Plane erkannt wird)
        visual.SetActive(false);
    }

     void Update()
    {

        // "Strahl" dauerhaft (Update) aus der Bildschirmmitte "schießen". Wenn dieser ein "Trackable", in unserem Fall eine Plane trifft wird diese Position/Rotation gespeichert.
        // Bezugsposition ist in diesem Fall die AR Camera
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes); // PlaneWithinInfinity oder Plane

        // Die Position/Rotation wird dauerhaft (Update) aktuell gehalten.
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            // Macht den PlacementIndicator sichtbar, sobald eine Plane getroffen wird
            if (!visual.activeInHierarchy)
                visual.SetActive(true);
        }

        //Erweiterung Maus/Finger Position

        if ((((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began) && (Distance == true) && (!DeleteToggle.isOn == true))))
        {
            Debug.Log("Mouse down");

            //Position wo Bildschirm gedrückt wird eritteln 
            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);
            //Debug Funktion ist zur Fehlerermittlung hilfreich. Es handelt sich um eine Ausgabe in der Konsole
            Debug.Log(ray);

            if (isPointerOverUI(Input.mousePosition))
            {
                Debug.Log("Do nothing!");
            }
            // GameObject an der Stelle spawnen, an der sich auch der Placementindicator befindet
            else
            {
                GameObject prefab_gameobject = Instantiate(ObjectToPlace, transform.position, transform.rotation);
            }
        }

    }

}
