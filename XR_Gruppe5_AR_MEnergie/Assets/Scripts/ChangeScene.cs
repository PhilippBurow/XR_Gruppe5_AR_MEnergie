using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Toggle Renewable;
    public Toggle Desaster;
    
    //Wenn die f�r Erneuerbare Energien zust�ndigen Buttons bet�tigt werden, wir auf den Index der Scene 1 addiert. Bei Buttons
    //f�r Umweltkatastrophen der Index 3, um auf den richten Screen zu kommen (s. Build Settings)
    public void ChangeScreen()
    {
        if (Renewable.isOn)  
        {
            Debug.Log("plus 1");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (Desaster.isOn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        }
    }
    //Wenn man sich auf einem Screen der Erneuerbare Energien beinhalten befinden, wird ein Index zur�ck gegangen.
    //befinden man sich auf der Startseite f�r Umweltkatastrophen, muss 3 Indize zur�ck gegangen werden. (s. Build Settings)
    public void Back()
    {
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "StartSceneEE" || SceneManager.GetActiveScene().name == "InfoScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (SceneManager.GetActiveScene().name == "ARScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        else if(SceneManager.GetActiveScene().name == "DisasterScene")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        }
    }
    //hier wird die Anwendung beendet
    public void Quit()
    {
        Debug.Log("Anwendung geschlossen!");
        Application.Quit();
    }

}
