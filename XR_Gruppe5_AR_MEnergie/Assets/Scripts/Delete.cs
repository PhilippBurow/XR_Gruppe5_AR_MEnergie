using UnityEngine;
using UnityEngine.UI;

// script to delete windturbine by clicking on the object

public class Delete : MonoBehaviour
{
    public Toggle DeleteToggle;     // delete Toggle "Löschen" on UI
    public Camera ARCamera;         // connection to AR Camera

    public void Update()
    {
        // input.GetMouseButtonDown equals touch on screen 
        if (DeleteToggle.isOn == true && Input.GetMouseButtonDown(0))       
        {
            Debug.Log("Löschen aktiv");
            // generates ray on touch position
            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);
            // checking ray function: ray position output
            Debug.Log(ray);
            // get information back from the raycast into variable "hit"
            RaycastHit hit;                                                 

            if (Physics.Raycast(ray, out hit))
            {
                // checks if touched collider is a capsule collider
                CapsuleCollider cc = hit.collider as CapsuleCollider;
                // if this is the case
                if (cc != null)
                {   // delete Game Object within the capsule collider                                                        
                    Destroy(cc.gameObject);                                 
                }
            }
        }
    }
}
