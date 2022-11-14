using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profeObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    public int idProfesor;
    public GameObject panelProfesores;

    void Start()
    {

    } 
    
    public void cambiarAPanelProfesor()
    {
        panelProfesores.SetActive(true);

        panelProfesor scriptPanelProfesor = panelProfesores.GetComponent<panelProfesor>();
        scriptPanelProfesor.idProfesor = idProfesor;
        
        scriptPanelProfesor.cambiarSegundaPantalla();
        // scriptPanelProfesor.CorrutinaObtenerDatos("1");
    }
}
