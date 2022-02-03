using UnityEngine;

// script to open URL

public class OpenURL : MonoBehaviour
{
    public void Quelle1()
    {
        Application.OpenURL("http://windmonitor.iee.fraunhofer.de/windmonitor_de/3_Onshore/2_technik/4_anlagengroesse/");
    }    
    public void Quelle2()
    {   
        Application.OpenURL("https://um.baden-wuerttemberg.de/de/energie/erneuerbare-energien/windenergie/faq-windenergie/welchen-flaechenbedarf-haben-windenergieanlagen/"); 
    }
}
