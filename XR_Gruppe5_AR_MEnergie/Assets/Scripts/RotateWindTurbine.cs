using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skript zum rotieren der Windturbinen-Rotoren

public class RotateWindTurbine : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Kopf der Windturbine dreht sich um die y-Achse mit dem Wert 190
        transform.Rotate(new Vector3(0f, 190f, 0f) * Time.deltaTime);
    }
}
