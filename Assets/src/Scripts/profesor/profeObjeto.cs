using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profeObjeto : MonoBehaviour
{
    public int idProfesor;
    public GameObject cambioPantallas;

    void Start()
    {
    } 
    
    public void cambiarAPanelProfesor()
    {
        MenuPrincipal scriptcambioPantallas = cambioPantallas.GetComponent<MenuPrincipal>();         
        scriptcambioPantallas.idProfesor = idProfesor;
        scriptcambioPantallas.cambiarSegundaPantallaUI();
    }
}
