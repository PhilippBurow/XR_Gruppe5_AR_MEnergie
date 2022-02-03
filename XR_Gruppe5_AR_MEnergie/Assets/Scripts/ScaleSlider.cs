using UnityEngine;
using UnityEngine.UI;

// Script to scale the windturbine's size by a slider on the UI

public class ScaleSlider : MonoBehaviour
{
    private Slider scaleSlider;                                                 
    void Start()
    {
        // searching for slider "ScaleSlider" in hierarchy
        scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();
        // when slider value changes go to function ScaleSliderUpdate with 
        // current game object size
        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);                                                                                         
    }                                                                           

    void ScaleSliderUpdate(float value)
    {
        // scale all dimensions with the same size depending on scale movement
        transform.localScale = new Vector3(value, value, value);                     
    }
}
