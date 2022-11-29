using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salonObjeto : MonoBehaviour
{
    public int idSalon;
    public GameObject cambioPantallas;

    void Start()
    {
    }

    public void cambiarAPanelSalon()
    {
        MenuPrincipal scriptcambioPantallas = cambioPantallas.GetComponent<MenuPrincipal>();         
        scriptcambioPantallas.idSalon = idSalon;

        scriptcambioPantallas.cambiarPrimerPantallaUI();
    }
}