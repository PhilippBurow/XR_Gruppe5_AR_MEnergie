using UnityEngine;

// Script to animate rotor blade rotation 

public class RotateWindTurbine : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Hub of the wind turbine rotates around the y-axis with the value 190
        transform.Rotate(new Vector3(0f, 190f, 0f) * Time.deltaTime);
    }
}
