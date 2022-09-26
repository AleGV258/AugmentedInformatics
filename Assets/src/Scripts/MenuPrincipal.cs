using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject pantallaPrincipal;
    public GameObject pantallaProfesores;
    //public GameObject pantallaCroquis;
    public GameObject pantallaCreditos;
    //public GameObject pantallaVerMas;
    public GameObject realidadAumentada;
    public GameObject virtualUI;
    bool activado = false;
    bool inicio = true;

    void Start()
    {
        arCamera = GameObject.Find("ARCamera");
    }

    public void encontrado()
    {
        activado = true;
        virtualUI.SetActive(false);
    }

    IEnumerator quitarPanel()
    {
        yield return new WaitForSeconds(30);
        virtualUI.SetActive(false);
        activado = false;
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

    

    public void cambiarPantallaRealidadAumentada()
    {
        pantallaPrincipal.SetActive(false);
        pantallaProfesores.SetActive(false);
        //pantallaCroquis.SetActive(false);
        pantallaCreditos.SetActive(false);
        //pantallaVerMas.SetActive(false);
        realidadAumentada.SetActive(true);
        virtualUI.SetActive(false);
    }

    public void cambiarPantallaVirtualUI()
    {
        if ((activado) && (realidadAumentada.activeSelf == true))
        {
            virtualUI.SetActive(true);
            StartCoroutine(quitarPanel());
        }
        else
        {
            virtualUI.SetActive(false);
        }
    }

    public void inicioApp()
    {
        if (inicio)
        {
            pantallaPrincipal.SetActive(true);
            realidadAumentada.SetActive(false);
            inicio = false;
        }
    }
}
