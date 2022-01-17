using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Placementindicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;
    public GameObject ObjectToPlace;
    private bool Distance = true; 
 
    // Wenn im Collider vom Prefab WindTurbine (Tag "Player") kann nicht gespawnt werden -> Kreis ist Rot.
     private void OnTriggerEnter(Collider other)
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

        // GameObject an der Stelle spawnen, an der sich auch der Placementindicator befindet
        if (((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began) && (Distance == true)))
        // if (Input.GetMouseButtonDown(0)) // erkennt Mauseingabe am PC (zum Testen)
        {
            GameObject prefab_gameobject = Instantiate(ObjectToPlace, transform.position, transform.rotation);
            
            // Game Object zerstören
            Destroy(prefab_gameobject, 60.0f); // Nach 60 Sekunden z.B.
        }
        
    }

}
