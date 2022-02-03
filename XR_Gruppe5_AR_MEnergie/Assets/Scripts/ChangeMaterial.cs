using UnityEngine;

// Script to change color of the wind turbine's base
// depending on distance 

public class ChangeMaterial : MonoBehaviour
{
    // connection to base material "M_Distance"
    public Material myMaterial;                     

    // function to check if two game objects collide
    private void OnTriggerEnter(Collider other)     
    {
        // compare tags of colliding game objects. "Player" is tagged to
        // windturbine prefab and Placementindicator
        if (other.CompareTag("Player"))              
        {
            // change base material to red
            myMaterial.color = Color.red;           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // compare tags of game objects. "Player" is tagged to windturbine
        // prefab and Placementindicator
        if (other.CompareTag("Player"))             
        {
            // base material remains red
            myMaterial.color = Color.red;                     
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // compare tags of departing game objects. "Player" is tagged to
        // windturbine prefab and Placementindicator
        if (other.CompareTag("Player"))             
        {
            // change base material to green
            myMaterial.color = Color.green;         
        }
    }
}
