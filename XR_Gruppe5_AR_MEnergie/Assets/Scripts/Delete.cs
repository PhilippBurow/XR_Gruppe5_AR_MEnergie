using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Delete : MonoBehaviour
{
    public Toggle DeleteToggle;
    // Update is called once per frame
    void Update()
    {
        
            Debug.Log("Löschen aktiv");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Schritt1");
                // Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                //Debug.Log(ray);
                /*RaycastHit hit;
                // Check if finger is over a UI element
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    Debug.Log("Touched the UI");
                }
                else if(Physics.Raycast(ray, out hit))
                {
                    if (Input.GetTouch(0).deltaTime > 0.2f)
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }*/
            }
        
    }
}
