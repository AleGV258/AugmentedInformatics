using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject pantallaPrincipal;
    public GameObject pantallaProfesores;
    //public GameObject pantallaCroquis;
    public GameObject pantallaCreditos;
    //public GameObject pantallaVerMas;
    public GameObject realidadAumentada;
    public GameObject virtualUI;
    bool activado = false;

    public void encontrado()
    {
        activado = true;
    }

    public void noEncontrado()
    {
        activado = false;
    }

    IEnumerator quitarPanel()
    {
        yield return new WaitForSeconds(20);
        virtualUI.SetActive(false);
    }

    void Start()
    {
        pantallaProfesores.SetActive(false);
        //pantallaCroquis.SetActive(false);
        pantallaCreditos.SetActive(false);
        //pantallaVerMas.SetActive(false);
        realidadAumentada.SetActive(false);
        virtualUI.SetActive(false);
        pantallaPrincipal.SetActive(true);
    }

    public void regresarMenuPrincipal()
    {
        pantallaPrincipal.SetActive(true);
        pantallaProfesores.SetActive(false);
        //pantallaCroquis.SetActive(false);
        pantallaCreditos.SetActive(false);
        //pantallaVerMas.SetActive(false);
        realidadAumentada.SetActive(false);
        virtualUI.SetActive(false);
    }

    public void cambiarPantallaProfesores()
    {
        pantallaPrincipal.SetActive(false);
        pantallaProfesores.SetActive(true);
        //pantallaCroquis.SetActive(false);
        pantallaCreditos.SetActive(false);
        //pantallaVerMas.SetActive(false);
        realidadAumentada.SetActive(false);
        virtualUI.SetActive(false);
    }

    /*public void cambiarPantallaCroquis()
    {

    }*/

    public void cambiarPantallaCreditos()
    {
        pantallaPrincipal.SetActive(false);
        pantallaProfesores.SetActive(false);
        //pantallaCroquis.SetActive(false);
        pantallaCreditos.SetActive(true);
        //pantallaVerMas.SetActive(false);
        realidadAumentada.SetActive(false);
        virtualUI.SetActive(false);
    }

    /*public void cambiarPantallaVerMas()
    {

    }*/

    public void cambiarPantallaRealidadAumentada()
    {
        pantallaPrincipal.SetActive(false);
        pantallaProfesores.SetActive(false);
        //pantallaCroquis.SetActive(false);
        pantallaCreditos.SetActive(false);
        //pantallaVerMas.SetActive(false);
        realidadAumentada.SetActive(true);
        if (activado)
        {
            virtualUI.SetActive(true);
            StartCoroutine(quitarPanel());
        }
        else
        {
            virtualUI.SetActive(false);
        }
    }
}
