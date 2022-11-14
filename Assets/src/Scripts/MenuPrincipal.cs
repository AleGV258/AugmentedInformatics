using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using Vuforia;

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
    public PlayableDirector timeline;

    bool activado = false;
    bool inicio = true;

    void Start()
    {
        StartCoroutine(desactivarCamara());
    }

    public void reproducirPantalla()
    {
        timeline.Play();
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

    IEnumerator desactivarCamara()
    {
        yield return new WaitForEndOfFrame();
        arCamera.SetActive(false);
    }

    public void regresarMenuPrincipal()
    {
        arCamera.SetActive(false);
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
        arCamera.SetActive(true);
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

    public void cambiarPantallaVerMas()
    {
        Application.OpenURL("http://unity3d.com/");
    }

    public void UnirseCD()
    {
        Application.OpenURL("https://www.uaq.mx/informatica/cede.html");
    }
}
