using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class profeObjeto : MonoBehaviour
{
    public int idProfesor;
    public GameObject panelProfesores;

    // Start is called before the first frame update
    void Start()
    {

    } 
    
    public void cambiarAPanelProfesor()
    {
        panelProfesores.SetActive(true);
        panelProfesor scriptPanelProfesor = panelProfesores.GetComponent <panelProfesor> ();
        scriptPanelProfesor.idProfesor = idProfesor;
        
        scriptPanelProfesor.cambiarSegundaPantalla();
        // scriptPanelProfesor.CorrutinaObtenerDatos("1");
    }
}
