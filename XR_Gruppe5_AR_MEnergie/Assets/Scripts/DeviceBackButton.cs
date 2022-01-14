using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeviceBackButton : MonoBehaviour
{
    int sceneIndex;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    // Update is called once per frame
    void Update()
    {

        if ((SceneManager.GetActiveScene().name == "StartSceneEE" || SceneManager.GetActiveScene().name == "ARScene") && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneIndex - 1);
        }
        else if (SceneManager.GetActiveScene().name == "DisasterScene" && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneIndex - 3);
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu" && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
