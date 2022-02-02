using UnityEngine;
using UnityEngine.UI;

// Script to scale the windturbine's size by a slider on the UI

public class ScaleSlider : MonoBehaviour
{
    private Slider scaleSlider;                                                 // connection to slider
    void Start()
    {
        // Slider "ScaleSlider" in Hierarchy finden
        scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();    // searching for slider "ScaleSlider" in hierarchy 
        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);              // when slider value changes go to function ScaleSliderUpdate with current                                                                           
    }                                                                           // game object size

    void ScaleSliderUpdate(float value)
    {
        transform.localScale = new Vector3(value, value, value);                // scale all dimensions with the same size depending on scale movement     
    }
}
