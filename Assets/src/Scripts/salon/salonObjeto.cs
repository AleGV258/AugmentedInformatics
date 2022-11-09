using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salonObjeto : MonoBehaviour
{
   // Start is called before the first frame update
    public int idSalon;
    public GameObject panelSegundaPantalla;
    void Start()
    {
    }


    void Update()
    {
        
    }
    // public void enviaidSalon()
    // {
    //     panelSalon scriptPanelSalon = panelSalon.GetComponent <panelSalon> ();
    //     scriptPanelSalon.idSalon = idSalon;
    //     Debug.Log("Se pasa id en enviaridSalon");
    //     scriptPanelSalon.cambiarPrimerPantalla();
    // }
    public void cambiarAPanelSalon()
    {
        panelSegundaPantalla.SetActive(true);
        
        panelSalon scriptPanelSalon = panelSegundaPantalla.GetComponent <panelSalon> ();
        scriptPanelSalon.idSalon = idSalon;
        
        scriptPanelSalon.cambiarPrimerPantalla();
        // scriptPanelProfesor.CorrutinaObtenerDatos("1");
    }
}