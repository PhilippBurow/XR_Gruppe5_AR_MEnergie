using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Toggle OneSceneUp;
    public Toggle FourScenesUp;
    public Toggle Home;
    public Toggle Help;
    
    //Wenn die für Erneuerbare Energien zuständigen Buttons betätigt werden, wir auf den Index der Scene 1 addiert. Bei Buttons
    //für Umweltkatastrophen der Index 3, um auf den richten Screen zu kommen (s. Build Settings)
    public void ChangeScreen()
    {
        if (OneSceneUp.isOn || SceneManager.GetActiveScene().name == "DisasterScene")  
        {
            Debug.Log("plus 1");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (FourScenesUp.isOn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        }
    }
    //Wenn man sich auf einem Screen der Erneuerbare Energien beinhalten befinden, wird ein Index zurück gegangen.
    //befinden man sich auf der Startseite für Umweltkatastrophen, muss 3 Indize zurück gegangen werden. (s. Build Settings)
    public void Back()
    {
        if (SceneManager.GetActiveScene().name == "DisasterScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        }
        if (SceneManager.GetActiveScene().name == "StartSceneEE" || SceneManager.GetActiveScene().name == "InfoScene" || SceneManager.GetActiveScene().name == "SmogScene" || Help.isOn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (Home.isOn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        
    }
    //hier wird die Anwendung beendet
    public void Quit()
    {
        Debug.Log("Anwendung geschlossen!");
        Application.Quit();
    }

}
