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
    public Camera ARCamera;

    public void Update()
    {
        if (DeleteToggle.isOn == true && Input.GetMouseButtonDown(0)) //wenn Toggle aktiv 
        {
            Debug.Log("Löschen aktiv");
            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray);
            RaycastHit hit;
            //Check if finger is over a UI element

            if (Physics.Raycast(ray, out hit))
            {
                CapsuleCollider cc = hit.collider as CapsuleCollider;
                if (cc != null)
                {
                    Destroy(cc.gameObject);
                }
            }
        }
        else if (DeleteToggle.isOn == false)
        {
            Debug.Log("exit");
        }
    }
}
