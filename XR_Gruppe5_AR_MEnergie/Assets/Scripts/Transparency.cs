using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transparency : MonoBehaviour
{
    public Image img;
    private Slider SmogSlider;

    // Start is called before the first frame update
    void Start()
    {
        // Slider in Hierarchy finden
        SmogSlider = GameObject.Find("SmogSlider").GetComponent<Slider>();
        SmogSlider.onValueChanged.AddListener(ScaleSliderUpdate);
    }

    void ScaleSliderUpdate(float value)
    {
        img.color = new Color(1.0f, 1.0f, 1.0f, value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
