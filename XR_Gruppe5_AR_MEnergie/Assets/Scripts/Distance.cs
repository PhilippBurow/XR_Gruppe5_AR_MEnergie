using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Entered the Windturbine-Trigger"); 
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Object is within Windturbine-Trigger");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Object Exited the Windturbine-Trigger");
    }
}
