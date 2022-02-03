using UnityEngine;
using UnityEngine.UI;

// Variate the transparency of the background image in the Smog scene with a slider

public class Transparency : MonoBehaviour
{
    public Image img;               // image whose transparency is changed
    private Slider SmogSlider;      

    // Start is called before the first frame update
    void Start()
    {
        // searching for slider "ScaleSlider" in hierarchy
        SmogSlider = GameObject.Find("SmogSlider").GetComponent<Slider>();  
        // when slider value changes go to function ScaleSliderUpdate with current
        SmogSlider.onValueChanged.AddListener(ScaleSliderUpdate);                                                                                      
    }

    void ScaleSliderUpdate(float value)
    {
        // change the transparency of the Image Color depending on scale movement
        img.color = new Color(1.0f, 1.0f, 1.0f, value);                     
    }
}




