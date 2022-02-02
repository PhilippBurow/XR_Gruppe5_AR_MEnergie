using UnityEngine;
using UnityEngine.SceneManagement;

// Script for integrating the device back button to get the previous scene 

public class DeviceBackButton : MonoBehaviour
{
    int sceneIndex;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;      // Set the sceneIndex variable to the index of the start scene
    }
    // Update is called once per frame
    void Update()
    {
        // As each scene has a fixed indize, the sceneIndex must be changed differently by the different paths ("Erneuerbare Energien darstellen" or "Umweltkatastrophe darstellen")

        if ((SceneManager.GetActiveScene().name == "StartSceneEE" || SceneManager.GetActiveScene().name == "ARScene") && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneIndex - 1);
        }
        else if (SceneManager.GetActiveScene().name == "DisasterScene" && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneIndex - 4); // 
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu" && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();  // quit the App if device back button is pressed in MainMenue
        }
    }
}
