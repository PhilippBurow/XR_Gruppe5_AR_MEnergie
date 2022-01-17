using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleSlider : MonoBehaviour
{
    // Erstellen einer Variable 
    private Slider scaleSlider;


    void Start()
    {
        // Slider in Hierarchy finden
        scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();
        scaleSlider.onValueChanged.AddListener(ScaleSliderUpdate);
    }

    // Einheitliche Variable für alle drei Scale-Variablen erstellen und diese mit dem ScaleSlider verknuepfen
    void ScaleSliderUpdate(float value)
    {
        transform.localScale = new Vector3(value, value, value);
            
            }
    void Update()
    {
       
    }
}
