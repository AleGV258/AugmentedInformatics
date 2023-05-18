using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salonObjeto : MonoBehaviour
{
    public int idSalon; // ID del salón
    public GameObject cambioPantallas; // GameObject del script de MenuPrincipal

    // Función para cambiar al panel de salón con el ID nuevo
    public void cambiarAPanelSalon()
    {
        MenuPrincipal scriptcambioPantallas = cambioPantallas.GetComponent<MenuPrincipal>(); // PanelSalon es el tipo de componente que se recupera y panel1Salones el GameObject del que se recupera el componente       
        scriptcambioPantallas.idSalon = idSalon; // Se envia el idSalon
        scriptcambioPantallas.cambiarPantallaVirtualUISalon(); // Se llama la función para cambiar de pantalla
    }
}