using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using Vuforia;

/* Script del menú principal, permite la navegación entre las pantallas de la interfaz UI y la interfaz AR, donde la interfaz AR, son los objetos que se colocan y se instancian sobre y al mostrar los ImageTargets de Vuforia, y en donde la interfaz UI, son los elementos instanciados y creados sobre la pantalla del usuario */
public class MenuPrincipal : MonoBehaviour
{
    public GameObject arCamera; // GameObject de la cámara del dispositivo
    public GameObject pantallaPrincipal; // GameObject de la interfaz de la pantalla principal
    public GameObject pantallaProfesores; // GameObject de la interfaz del panel de búsqueda
    //public GameObject pantallaCroquis; // GameObject de la interfaz del croquis con las aulas en imágenes
    public GameObject pantallaCreditos; // GameObject de la interfaz de los créditos de los creadores de la aplicación
    public GameObject realidadAumentada; // GameObject de la interfaz de la cámara para la realidad aumentada, de los paneles de salón y profesor, pantalla que muestra la flecha de regreso a la aplicación principal
    public GameObject virtualUI; // GameObject de la interfaz de usuarios de los paneles sin realidad aumentada, de los paneles de salón y profesor
    public PlayableDirector timeline; // Animación de los paneles de realidad aumentada al encontrarse el ImageTarget
    float contadorQuitarPanel = 0; // Contador que aumenta para detectar el tiempo que la interfaz virtual de los paneles está activa

    // Función que se ejecuta al inicio y antes de todo, inclusive si el script está desactivado
    void Awake(){
        pantallaPrincipal.SetActive(true); // Se activa la pantalla del menú principal
        pantallaProfesores.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        //pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
    }

    // Función que se ejecuta al iniciar la aplicación
    void Start()
    {
        // La corrutina se coloca aquí y no en awake, para dar tiempo a la aplicación a detectar la cámara
        StartCoroutine(desactivarCamara()); // Se inicia la corrutina de detectar y desactivar la cámara
    }

    // Función que se ejecuta y actualiza cada frame que la aplicación se ejecute
    void Update()
    {
        // Se verifica que la interfaz de los paneles esté activada, para poder contabilizar cuanto tiempo está activa
        if(virtualUI.activeSelf == true){
            contadorQuitarPanel += Time.deltaTime; // Se le suma al contador el tiempo uno entre los FPS a los que el dispositivo puede correr
        }
        // Se verifica que el contador no supere los 35.0 o 35 segundos, si se pasa, se desactiva el panel y reinicia el contador
        if(contadorQuitarPanel >= 35.0f){
            virtualUI.SetActive(false); // Se desactivan los paneles de salón y profesor, después de 35 segundos
            contadorQuitarPanel = 0; // Se reinicia el contador
        }
    }

    // Función para reproducir la animación del panel de salón al encontrarse el ImageTarget
    public void reproducirPantalla()
    {
        timeline.Play(); // Reproducción de la animación al aparecer el panel de AR
    }

    // Función IEnumerator que se manda llamar al iniciar la aplicación y su corutina, la función desactiva al instante de que empieza el juego la cámara, de esta forma el dispositivo tiene tiempo de dentificar la camara para poder manejarla, de otra forma, el dispositivo no reconoce las cámaras.
    IEnumerator desactivarCamara()
    {
        yield return new WaitForEndOfFrame(); // Espera al primer frame de carga de la aplicación
        arCamera.SetActive(false); // Desactiva la cámara, esto se hace para consumir menos recursos en la aplicación
    }

    // Función que activa la interfaz del menú principal, y desactiva todas las demás
    public void regresarMenuPrincipal()
    {
        arCamera.SetActive(false); // Se desactiva la cámara
        pantallaPrincipal.SetActive(true); // Se activa la pantalla del menú principal
        pantallaProfesores.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        //pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
    }

    // Función que activa la interfaz de la búsqueda de profesores y salones, y desactiva todas las demás
    public void cambiarPantallaProfesores()
    {
        arCamera.SetActive(false); // Se desactiva la cámara
        pantallaPrincipal.SetActive(false); // Se desactiva la pantalla del menú principal
        pantallaProfesores.SetActive(true); // Se activa la pantalla de búsqueda de profesores y salones
        //pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
    }

    // Función que activa la interfaz de la pantalla del croquis UI, y desactiva todas las demás
    /*public void cambiarPantallaCroquis()
    {
        arCamera.SetActive(false); // Se desactiva la cámara
        pantallaPrincipal.SetActive(false); // Se desactiva la pantalla del menú principal
        pantallaProfesores.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        pantallaCroquis.SetActive(true); // Se activa a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
    }*/

    // Función que activa la interfaz de los créditos de la aplicación, y desactiva todas las demás
    public void cambiarPantallaCreditos()
    {
        arCamera.SetActive(false); // Se desactiva la cámara
        pantallaPrincipal.SetActive(false); // Se desactiva la pantalla del menú principal
        pantallaProfesores.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        //pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(true); // Se activa la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
    }

    // Función que activa la cámara, la interfaz de la realidad aumentada y la flecha de regreso, y desactiva todas las demás
    public void cambiarPantallaRealidadAumentada()
    {
        arCamera.SetActive(true); // Se activa la cámara
        pantallaPrincipal.SetActive(false); // Se desactiva la pantalla del menú principal
        pantallaProfesores.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        //pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(true); // Se activa la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
    }

    // Función que activa la cámara, la interfaz UI de profesores y salones, y desactiva todas las demás
    public void cambiarPantallaVirtualUI()
    {
        // Se verifica que la cámara y la interfaz de la AR estén activadas
        if ((realidadAumentada.activeSelf == true) && (arCamera.activeSelf == true))
        {
            virtualUI.SetActive(true); // Se activa los paneles UI de salones y profesores
            contadorQuitarPanel = 0; // El contador del tiempo de la interfaz UI se restablece para empezar nuevamente
        }
    }

    // Función que redirige al usuario al repositorio de toda la información desplegada en la aplicación
    public void cambiarPantallaVerMas()
    {
        Application.OpenURL("http://unity3d.com/"); // Redirige a una URL
    }

    // Función que redirige al usuario a la página de la facultad para conocer a Centro de Desarrollo de la Facultad de Informática
    public void UnirseCD()
    {
        Application.OpenURL("https://www.uaq.mx/informatica/cede.html"); // Redirige a una URL
    }







    //Probar cambiar los metodos de panelSalon y panelProfesor a menú principal
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
        // paneles.transform.position = new Vector3(0,0,0);
        paneles.GetComponent<RectTransform>().localPosition = Vector3.zero;
        paneles.GetComponent<RectTransform>().localRotation = Quaternion.Euler(90f, 0f, 0f);
    }
    
}
