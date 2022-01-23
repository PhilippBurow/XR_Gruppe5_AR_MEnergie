using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Skript zum variieren der Größe der Windturbinen-Prefabs über einen Slider im UI

public class ScaleSlider : MonoBehaviour
{
    // Erstellen der Slider-Variable 
    private Slider scaleSlider;
    void Start()
    {
        // Slider "ScaleSlider" in Hierarchy finden
        scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();
        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);
    }

    // Einheitliche Variable "value" für alle drei Scale-Variablen erstellen und diese mit dem
    // ScaleSlider verknuepfen. So werden die x-,y- und z-Variable gleich variiert  
    void ScaleSliderUpdate(float value)
    {
        transform.localScale = new Vector3(value, value, value);     
    }

}
