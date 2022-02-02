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
        SmogSlider = GameObject.Find("SmogSlider").GetComponent<Slider>();  // searching for slider "ScaleSlider" in hierarchy
        SmogSlider.onValueChanged.AddListener(ScaleSliderUpdate);           // when slider value changes go to function ScaleSliderUpdate with current                                                                           
    }

    void ScaleSliderUpdate(float value)
    {
        img.color = new Color(1.0f, 1.0f, 1.0f, value);                     // change the transparency of the Image Color depending on scale movement
    }
}




