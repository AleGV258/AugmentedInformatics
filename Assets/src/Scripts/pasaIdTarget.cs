using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasaIdTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public int idProfesor;
    public GameObject panelProfesores;
    void Start()
    {
    }


    void Update()
    {
        
    }
    public void enviaIdProfesor()
    {
        panelProfesor scriptPanelProfesor = panelProfesores.GetComponent <panelProfesor> ();
        scriptPanelProfesor.idProfesor = idProfesor;
        Debug.Log("Se pasa id en enviarIdProfesor");
    }
}