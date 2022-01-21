using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenURL : MonoBehaviour
{
    public Button Button1;
    public Button Button2;

    public void Quelle1()
    {
        Application.OpenURL("http://windmonitor.iee.fraunhofer.de/windmonitor_de/3_Onshore/2_technik/4_anlagengroesse/");
    }    
    public void Quelle2()
    {   
        Application.OpenURL("https://um.baden-wuerttemberg.de/de/energie/erneuerbare-energien/windenergie/faq-windenergie/welchen-flaechenbedarf-haben-windenergieanlagen/"); 
    }
}
