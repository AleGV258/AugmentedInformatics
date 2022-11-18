using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salonObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    public int idSalon;
    public GameObject panelSalones;

    void Start()
    {

    }

    public void cambiarAPanelSalon()
    {
        panelSalones.SetActive(true);
        
        panelSalon scriptPanelSalon = panelSalones.GetComponent<panelSalon>();
        scriptPanelSalon.idSalon = idSalon;
        
        scriptPanelSalon.cambiarPrimerPantallaUI();
        // scriptPanelProfesor.CorrutinaObtenerDatos("1");
    }

    // public void enviaidSalon()
    // {
    //     panelSalon scriptPanelSalon = panelSalon.GetComponent <panelSalon> ();
    //     scriptPanelSalon.idSalon = idSalon;
    //     Debug.Log("Se pasa id en enviaridSalon");
    //     scriptPanelSalon.cambiarPrimerPantalla();
    // }
}