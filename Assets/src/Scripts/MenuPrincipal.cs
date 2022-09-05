using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject pantallaPrincipal;
    public GameObject pantallaProfesores;
    /*public GameObject pantallaCroquis;
    public GameObject pantallaCreditos;
    public GameObject pantallaVerMas;*/
    public GameObject realidadAumentada;

    void Start()
    {
        pantallaPrincipal.SetActive(false);
        pantallaProfesores.SetActive(false);
        /*pantallaCroquis.SetActive(false);
        pantallaCreditos.SetActive(false);
        pantallaVerMas.SetActive(false);*/
        realidadAumentada.SetActive(true);
    }

    public void regresarMenuPrincipal()
    {
        pantallaPrincipal.SetActive(true);
        pantallaProfesores.SetActive(false);
        /*pantallaCroquis.SetActive(false);
        pantallaCreditos.SetActive(false);
        pantallaVerMas.SetActive(false);*/
        realidadAumentada.SetActive(false);
    }

    public void cambiarPantallaProfesores()
    {
        pantallaPrincipal.SetActive(false);
        pantallaProfesores.SetActive(true);
        /*pantallaCroquis.SetActive(false);
        pantallaCreditos.SetActive(false);
        pantallaVerMas.SetActive(false);*/
        realidadAumentada.SetActive(false);
    }

    /*public void cambiarPantallaCroquis()
    {

    }

    public void cambiarPantallaCreditos()
    {

    }

    public void cambiarPantallaVerMas()
    {

    }*/

    public void cambiarPantallaRealidadAumentada()
    {
        pantallaPrincipal.SetActive(false);
        pantallaProfesores.SetActive(false);
        /*pantallaCroquis.SetActive(false);
        pantallaCreditos.SetActive(false);
        pantallaVerMas.SetActive(false);*/
        realidadAumentada.SetActive(true);
    }
}
