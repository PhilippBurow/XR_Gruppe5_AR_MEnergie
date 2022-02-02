using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Script to change between different scenes and quit the app
// for detailed explanation see "Entwicklungsdokumentation"
// to see scene index mapping go to "File" > "Build Settings"

public class ChangeScene : MonoBehaviour
{
    public Toggle OneSceneUp;           // by clicking this button, scene index add plus one
    public Toggle FourScenesUp;         // by clicking this button, scene index add plus four
    public Toggle Home;                 // this toggle is used in scene "ARScene" to get two scenes back
    public Toggle Help;                 // this toggle is used in scene "ARScene" to get one scenes back

    public void ChangeScreen()
    {
        if (OneSceneUp.isOn)  
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   // adding index one on active scene
        }
        else if (FourScenesUp.isOn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);   // adding index four on active scene
        }
    }
    
    public void Back()
    {
        if (SceneManager.GetActiveScene().name == "DisasterScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);   // if you are in DisasterScene, scene index goes four steps back
        }
        if (SceneManager.GetActiveScene().name == "StartSceneEE" || SceneManager.GetActiveScene().name == "InfoScene" 
            || SceneManager.GetActiveScene().name == "SmogScene" || Help.isOn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);   // if you are in one scene mentioned above or Help Button in ARScene is pressed
        }                                                                           // scene index goes one step back
        if (Home.isOn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);   // if Home Button in AR Scene is pressed, scene index goes two steps back
        }
        
    }
    
    public void Quit()
    {
        Debug.Log("Anwendung geschlossen!");                                        // Control statement because desktop application does not quit
        Application.Quit();
    }

}
