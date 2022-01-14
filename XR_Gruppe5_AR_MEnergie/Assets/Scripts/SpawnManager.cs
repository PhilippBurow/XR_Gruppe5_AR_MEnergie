using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{

    public GameObject WindTurbinePrefab;
    public Camera ARCamera;
    public GameObject SpawnedWindTurbine;
    public Toggle Delete;

    private List<RaycastResult> raycastResults = new List<RaycastResult>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            else
            {
                SpawnedWindTurbine = Instantiate(WindTurbinePrefab, ray.origin, Quaternion.identity);
            }
        }

        // Neuer Abschnitt zu Testen des Löschen
        // Bedingung Mausposition + Toggle (+ Abfrage Wenn Mausposition über Prefab (Windturbine))

       // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
       // {
       //     if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // && Delete.isOn)
       //     {
       //         Destroy(WindTurbinePrefab);
        //    }
       // }
        // Bis Hier
    }

    private bool isPointerOverUI(Vector2 fingerPosition)
    {
        PointerEventData eventDataPosition = new PointerEventData(EventSystem.current);
        eventDataPosition.position = fingerPosition;
        EventSystem.current.RaycastAll(eventDataPosition, raycastResults);
        return raycastResults.Count > 0; //if greater than zero, that means we hit a UI Element
    }
}
