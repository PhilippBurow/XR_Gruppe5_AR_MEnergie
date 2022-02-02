using UnityEngine;
using UnityEngine.UI;

// Script to delete windturbine by clicking on the object

public class Delete : MonoBehaviour
{
    public Toggle DeleteToggle;                                             // delete Toggle "Löschen" on UI
    public Camera ARCamera;                                                 // connection to AR Camera

    public void Update()
    {
        if (DeleteToggle.isOn == true && Input.GetMouseButtonDown(0))       // input.GetMouseButtonDown equals touch on screen 
        {
            Debug.Log("Löschen aktiv");                                     
            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);       // generates ray on touch position
            Debug.Log(ray);                                                 // checking ray function: ray position output
            RaycastHit hit;                                                 // get information back from the raycast into variable "hit"

            if (Physics.Raycast(ray, out hit))
            {
                CapsuleCollider cc = hit.collider as CapsuleCollider;       // checks if touched collider is a capsule collider 
                if (cc != null)                                             // if this is the case
                {                                                           
                    Destroy(cc.gameObject);                                 // delete Game Object within the capsule collider
                }
            }
        }
    }
}
