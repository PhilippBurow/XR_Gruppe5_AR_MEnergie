using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Skript zum Variieren der Transparenz des Hintergrundbildes in der Sceen Smog über einen
// Slider im UI 

public class Transparency : MonoBehaviour
{
    // Variablen für die Smog-Sceen festlegen
    public Image img; // Hintergrundbild von dem die Transparenz geändert wird
    private Slider SmogSlider; // Slider über den in UI die Transparenz geändert werden kann 

    // Start is called before the first frame update
    void Start()
    {
        // Slider "SmogSlider" in Hierarchy finden 
        SmogSlider = GameObject.Find("SmogSlider").GetComponent<Slider>();
        SmogSlider.onValueChanged.AddListener(ScaleSliderUpdate);
    }

    void ScaleSliderUpdate(float value)
    {
        // Transparenz des Hintergrundbildes über "value" verändern
        img.color = new Color(1.0f, 1.0f, 1.0f, value); 
    }

}




