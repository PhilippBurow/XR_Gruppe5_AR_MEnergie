using UnityEngine;
using UnityEngine.UI;

// Script to delete windturbine by clicking on the object

public class Delete : MonoBehaviour
{
    public Toggle DeleteToggle;                                             // Delete Toggle "Löschen" on UI
    public Camera ARCamera;                                                 // Connection to AR Camera

    public void Update()
    {
        if (DeleteToggle.isOn == true && Input.GetMouseButtonDown(0))       // Input.GetMouseButtonDown equals touch on screen 
        {
            Debug.Log("Löschen aktiv");                                     
            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);       // Generates ray on touch position
            Debug.Log(ray);                                                 // Checking ray function: ray position output
            RaycastHit hit;                                                 // get information back from the raycast into variable "hit"
            //Check if finger is over a UI element

            if (Physics.Raycast(ray, out hit))
            {
                CapsuleCollider cc = hit.collider as CapsuleCollider;       // checks if touched collider is a capsule collider 
                if (cc != null)                                             // if this is the case
                {                                                           //
                    Destroy(cc.gameObject);                                 // delete Game Object within the capsule collider
                }
            }
        }
    }
}
