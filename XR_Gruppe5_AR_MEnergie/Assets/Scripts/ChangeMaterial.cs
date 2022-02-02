using UnityEngine;

// Script to change color of the wind turbine's base depending on distance 

public class ChangeMaterial : MonoBehaviour
{
    public Material myMaterial;                     // connection to base material "M_Distance"

    private void OnTriggerEnter(Collider other)     // function to check if two game objects collide
    {
        if(other.CompareTag("Player"))              // compare tags of colliding game objects. "Player" is tagged to windturbine prefab and Placementindicator
        {
            myMaterial.color = Color.red;           // change base material to red
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))             // compare tags of game objects. "Player" is tagged to windturbine prefab and Placementindicator
        {
            myMaterial.color = Color.red;           // base material remains red          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))             // compare tags of departing game objects. "Player" is tagged to windturbine prefab and Placementindicator
        {
            myMaterial.color = Color.green;         // change base material to green
        }
    }
}
