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
    float contadorQuitarPanel = 0;

    void Start()
    {
        StartCoroutine(desactivarCamara());
    }

    void Update()
    {
        if(virtualUI.activeSelf == true){
            contadorQuitarPanel += Time.deltaTime;
        }
        if(contadorQuitarPanel >= 35.0f){
            virtualUI.SetActive(false);
            activado = false;
            contadorQuitarPanel = 0;
        }
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
            contadorQuitarPanel = 0;
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


    //Probar cambiar los metodos de panelSalon y panelProfesor a menu principal
    public GameObject panel1Salon;
    public GameObject panel1SalonUI;
    public GameObject panel2Profesor;
    public GameObject panel2ProfesorUI;
    public GameObject interfazAR;
    public GameObject panelBusqueda;
    
    public void cambiarPrimerPantalla()//Salon
    {
        panel1Salon.SetActive(true);
        panel1SalonUI.SetActive(true);
        
        panel2Profesor.SetActive(false);
        panel2ProfesorUI.SetActive(false);
        
        panelBusqueda.SetActive(false);
        
        arCamera.SetActive(true);
        
        interfazAR.SetActive(false);

        realidadAumentada.SetActive(true);

        panelSalon scriptPanelSalon = panel1Salon.GetComponent<panelSalon>();
        // scriptPanelSalon.idSalon = idSalon;
        
        StartCoroutine(scriptPanelSalon.CorrutinaObtenerDatos());
    }

    public void cambiarPrimerPantallaUI()//Salon
    {
        panel1Salon.SetActive(true);
        
        panel1SalonUI.SetActive(true);

        panel2Profesor.SetActive(false);
        panel2ProfesorUI.SetActive(false);

        panelBusqueda.SetActive(false);
        
        arCamera.SetActive(true);
        
        interfazAR.SetActive(true);
        realidadAumentada.SetActive(true);

        panelSalon scriptPanelSalonUI = panel1SalonUI.GetComponent<panelSalon>();
        // idSalon = scriptPanelSalonUI.idSalon; // Se envia del en el que se encuentra 
        
        StartCoroutine(scriptPanelSalonUI.CorrutinaObtenerDatos());
    }
    public void cambiarSegundaPantalla()//Profesor
    {
        panel1Salon.SetActive(false);
        panel2Profesor.SetActive(true);
        panel1SalonUI.SetActive(false);
        panel2ProfesorUI.SetActive(true);
        panelBusqueda.SetActive(false);
        arCamera.SetActive(true);
        interfazAR.SetActive(false);
        realidadAumentada.SetActive(true);

        panelProfesor scriptPanelProfesor = panel2Profesor.GetComponent<panelProfesor>(); 
        StartCoroutine(scriptPanelProfesor.CorrutinaObtenerDatos());
    }
    public void cambiarSegundaPantallaUI()//Profesor
    {
        panel1Salon.SetActive(false);
        panel2Profesor.SetActive(true);
        panel1SalonUI.SetActive(false);
        panel2ProfesorUI.SetActive(true);
        panelBusqueda.SetActive(false);
        arCamera.SetActive(true);
        interfazAR.SetActive(true);
        realidadAumentada.SetActive(true);

        panelProfesor scriptPanelProfesorUI = panel2ProfesorUI.GetComponent<panelProfesor>();
        StartCoroutine(scriptPanelProfesorUI.CorrutinaObtenerDatos());
    }

    public GameObject targetRecibido;
    public GameObject paneles;
    public int idSalon =0;
    public int idProfesor = 0;
    public void cambiarPadrePanelesTarget()
    {
        //Pasar ID
        Debug.Log("El nuevo idSalon es " + idSalon);
        //Iniciar obtener Datos
        //Cambiar Padre        
        paneles.transform.parent = targetRecibido.transform;
    }
    
}
