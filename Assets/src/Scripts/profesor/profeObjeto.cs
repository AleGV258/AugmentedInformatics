using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profeObjeto : MonoBehaviour
{
    public int idProfesor; // ID del profesor
    public GameObject cambioPantallas; // GameObject del script de MenuPrincipal
    
    // Función para cambiar al panel de profesor con el ID nuevo
    public void cambiarAPanelProfesor()
    {
        MenuPrincipal scriptcambioPantallas = cambioPantallas.GetComponent<MenuPrincipal>(); // Panelprofesor es el tipo de componente que se recupera y panel1Profesores el GameObject del que se recupera el componente        
        scriptcambioPantallas.idProfesor = idProfesor; // Se envia el idProfesor
        scriptcambioPantallas.cambiarPantallaVirtualUIProfesor(); // Se llama la función para cambiar de pantalla
    }
}
