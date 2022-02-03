using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// script to change between different scenes and quit the app
// for detailed explanation see "Entwicklungsdokumentation"
// to see scene index mapping go to "File" > "Build Settings"

public class ChangeScene : MonoBehaviour
{
    public Toggle OneSceneUp;      // by clicking this button, scene index add plus one
    public Toggle FourScenesUp;    // by clicking this button, scene index add plus four
    public Toggle Home;            // this toggle is used in scene "ARScene" to get two scenes back
    public Toggle Help;            // this toggle is used in scene "ARScene" to get one scenes back

    public void ChangeScreen()
    {
        if (OneSceneUp.isOn)  
        {
            // adding index one on active scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
        }
        
        else if (FourScenesUp.isOn)
        {
            // adding index four on active scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);   
        }
    }
    
    public void Back()

    // when changing scene indices (buildIndex), the script "DeviceBackButton" must also be modified!!!
    {
        if (SceneManager.GetActiveScene().name == "DisasterScene")
        {
            // if you are in DisasterScene, scene index goes four steps back
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);   
        }

        if (SceneManager.GetActiveScene().name == "StartSceneEE" || SceneManager.GetActiveScene().name ==
            "InfoScene" || SceneManager.GetActiveScene().name == "SmogScene" || Help.isOn)
        {
            // if you are in one scene mentioned above or Help Button in ARScene is pressed
            // scene index goes one step back
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);   
        }                                                                           
        
        if (Home.isOn)
        {
            // if Home Button in AR Scene is pressed, scene index goes two steps back
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);   
        }    
    }
    
    public void Quit()
    {
        // control statement because desktop application does not quit
        Debug.Log("Anwendung geschlossen!");                                        
        Application.Quit();
    }
}
