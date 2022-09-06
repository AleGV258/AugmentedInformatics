using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class profeObjeto : MonoBehaviour
{
    public int idProfesor;
    // Start is called before the first frame update
    void Start()
    {
    } 
    public GameObject panelProfesores;
    
    public void cambiarDePanel()
    {
        panelProfesores.SetActive(true);
        panelProfesor scriptPanelProfesor = panelProfesores.GetComponent <panelProfesor> ();
        scriptPanelProfesor.idProfesor = idProfesor;
        
        scriptPanelProfesor.cambiarPrimerPantalla();
        // scriptPanelProfesor.CorrutinaObtenerDatos("1");
    }
}
