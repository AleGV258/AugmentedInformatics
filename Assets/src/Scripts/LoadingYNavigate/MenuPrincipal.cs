using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using TMPro;
using Vuforia;
using UnityEngine.Networking;

/* Script del menú principal, permite la navegación entre las pantallas de la interfaz UI y la interfaz AR, donde la interfaz AR, son los objetos que se colocan y se instancian sobre y al mostrar los ImageTargets de Vuforia, y en donde la interfaz UI, son los elementos instanciados y creados sobre la pantalla del usuario */
public class MenuPrincipal : MonoBehaviour
{
    public GameObject arCamera; // GameObject de la cámara del dispositivo
    public GameObject pantallaPrincipal; // GameObject de la interfaz de la pantalla principal
    public GameObject panelBusqueda; // GameObject de la interfaz del panel de búsqueda
    public GameObject pantallaCroquis; // GameObject de la interfaz del croquis con las aulas en imágenes
    public GameObject pantallaCreditos; // GameObject de la interfaz de los créditos de los creadores de la aplicación
    public GameObject realidadAumentada; // GameObject de la interfaz de la cámara para la realidad aumentada, de los paneles de salón y profesor, pantalla que muestra la flecha de regreso a la aplicación principal
    public GameObject virtualUI; // GameObject de la interfaz de usuarios de los paneles sin realidad aumentada, de los paneles de salón y profesor
    public GameObject pantallLogin; // GameObject de la interfaz del login de la aplicación 
    public GameObject Targets; // GameObject de los ImageTargets de la aplicación
    public Animator aparecerAR; // Animación de los paneles de realidad aumentada al encontrarse el ImageTarget
    public Animator aparecerUI; // Animación de los paneles de interfaz de usuario al encontrarse el ImageTarget
    float contadorQuitarPanel = 0; // Contador que aumenta para detectar el tiempo que la interfaz virtual de los paneles está activa

    public GameObject panel1SalonAR; // GameObject del panel1 Salón
    public GameObject panel2ProfesorAR; // GameObject del panel2 Profesor
    public GameObject panel1SalonUI; // GameObject del panel Salón UI
    public GameObject panel2ProfesorUI; // GameObject del panel2 Profesor UI

    public GameObject targetRecibido; // GameObject del nuevo target recibido, donde se cambia la interfaz de realidad aumentada
    public GameObject paneles; // GameObject del target donde se posiciono la interfaz, para modificar sus propiedades
    public int idSalon = 0; // ID del salón que se muestra en el panel
    public int idProfesor = 0; // ID del profesor que se muestra en el panel
    public int opcionCamara = 1; // Número que define donde se encuentra el usuario para la navegación

    public GameObject ObtenerDatosSalon;
    public GameObject ObtenerDatosProfesor;

    public TMP_InputField EntradaExpediente; // Variable para el ingreso del expediente
    public TMP_InputField EntradaContrasena; // Variable para el ingreso de la contaseña

    public string API = "http://148.220.52.101/api/datos"; // API

    // Función que se ejecuta al inicio y antes de todo, inclusive si el script está desactivado
    void Awake(){
        pantallLogin.SetActive(true); // Se activa la pantalla de login
        pantallaPrincipal.SetActive(false); // Se desactiva la pantalla del menú principal
        panelBusqueda.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
        // Targets.SetActive(false); // Se desactivan los ImageTargets
    }

    // Función que se ejecuta al iniciar la aplicación y en su primer frame
    void Start()
    {
        // BORRAR PRUEBA -------------------------------------------
        Debug.Log(EntradaExpediente.text);
        Debug.Log(EntradaContrasena.text);
        // BORRAR PRUEBA -------------------------------------------

        // La corrutina se coloca aquí y no en awake, para dar tiempo a la aplicación a detectar la cámara
        StartCoroutine(desactivarCamara()); // Se inicia la corrutina de detectar y desactivar la cámara
        // Targets.SetActive(true); // Se activan los ImageTargets
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
            StartCoroutine(quitarPantallaUI()); // Se manda llamar al trigger desactivar la animación de panel realidad aumentada, se desactivan los paneles de salón y profesor, después de 35 segundos
            contadorQuitarPanel = 0; // Se reinicia el contador
        }
        // Se verifica que no este prendida la cámara al bloquear el dispositivo
        if((arCamera.activeSelf == true && pantallaPrincipal.activeSelf == true) || (arCamera.activeSelf == true && pantallaCroquis.activeSelf == true) || (arCamera.activeSelf == true && pantallaCreditos.activeSelf == true) || (arCamera.activeSelf == true && panelBusqueda.activeSelf == true)){
            arCamera.SetActive(false); // Desactiva la cámara, esto se hace para consumir menos recursos en la aplicación
        }
    }

    // Función IEnumerator para reproducir la animación del panel de salón al encontrarse el ImageTarget
    IEnumerator quitarPantallaAR()
    {
        aparecerAR.SetTrigger("AparecerAR"); // Reproducción de la animación al aparecer el panel de AR
        yield return new WaitForSeconds(2); // Esperar 1 Segundo
    }

    // Función IEnumerator para reproducir la animación del panel de salón al perderse el ImageTarget
    IEnumerator quitarPantallaUI()
    {
        aparecerUI.SetTrigger("AparecerUI"); // Reproducción de la animación al aparecer el panel de UI
        yield return new WaitForSeconds(2); // Esperar 1 Segundo
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
    }

    // Función IEnumerator que se manda llamar al iniciar la aplicación y su corutina, la función desactiva al instante de que empieza el juego la cámara, de esta forma el dispositivo tiene tiempo de dentificar la camara para poder manejarla, de otra forma, el dispositivo no reconoce las cámaras.
    IEnumerator desactivarCamara()
    {
        yield return new WaitForEndOfFrame(); // Espera al primer frame de carga de la aplicación
        arCamera.SetActive(false); // Desactiva la cámara, esto se hace para consumir menos recursos en la aplicación
    }

    // Función que manda llamar a eliminar el panel virtual UI para desaparecer el panel
    // public void cerrarPanelUI(){
    //     StartCoroutine(quitarPantallaUI()); // Se manda llamar al trigger desactivar la animación de panel realidad aumentada
    // }

    // Función que activa la interfaz del menú principal, y desactiva todas las demás
    public void regresarMenuPrincipal()
    {
        arCamera.SetActive(false); // Se desactiva la cámara
        pantallLogin.SetActive(false); // Se desactiva la pantalla de login
        pantallaPrincipal.SetActive(true); // Se activa la pantalla del menú principal
        panelBusqueda.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
        // Targets.SetActive(false); // Se desactivan los ImageTargets
    }

    // Función que activa la interfaz del panel búsqueda, y desactiva todas las demás
    public void regresarPanelBusqueda()
    {
        arCamera.SetActive(false); // Se desactiva la cámara
        pantallLogin.SetActive(false); // Se desactiva la pantalla de login
        pantallaPrincipal.SetActive(false); // Se activa la pantalla del menú principal
        panelBusqueda.SetActive(true); // Se desactiva la pantalla de búsqueda de profesores y salones
        pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
        // Targets.SetActive(false); // Se desactivan los ImageTargets
    }

    // Función que revisa por donde navego el usuario para que la historia de navegación corresponda
    public void revisarNavegacion(){
        if(opcionCamara == 1){
            regresarMenuPrincipal(); // Si es 1 es navegación de la cámara
        }else if(opcionCamara == 2){
            regresarPanelBusqueda(); // Si es 2 es navegación de la búsqueda
        }
    }

    // Función que activa la interfaz de la búsqueda de profesores y salones, y desactiva todas las demás
    public void cambiarPanelBusqueda()
    {
        arCamera.SetActive(false); // Se desactiva la cámara
        pantallLogin.SetActive(false); // Se desactiva la pantalla de login
        pantallaPrincipal.SetActive(false); // Se desactiva la pantalla del menú principal
        panelBusqueda.SetActive(true); // Se activa la pantalla de búsqueda de profesores y salones
        pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
        // Targets.SetActive(false); // Se desactivan los ImageTargets
    }

    // Función que activa la interfaz de la pantalla del croquis UI, y desactiva todas las demás
    public void cambiarPantallaCroquis()
    {
        arCamera.SetActive(false); // Se desactiva la cámara
        pantallLogin.SetActive(false); // Se desactiva la pantalla de login
        pantallaPrincipal.SetActive(false); // Se desactiva la pantalla del menú principal
        panelBusqueda.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        pantallaCroquis.SetActive(true); // Se activa a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
        // Targets.SetActive(false); // Se desactivan los ImageTargets
    }

    // Función que activa la interfaz de los créditos de la aplicación, y desactiva todas las demás
    public void cambiarPantallaCreditos()
    {
        arCamera.SetActive(false); // Se desactiva la cámara
        pantallLogin.SetActive(false); // Se desactiva la pantalla de login
        pantallaPrincipal.SetActive(false); // Se desactiva la pantalla del menú principal
        panelBusqueda.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(true); // Se activa la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
        // Targets.SetActive(false); // Se desactivan los ImageTargets
    }

    // Función que activa la cámara, la interfaz de la realidad aumentada para el panel de salon y la flecha de regreso, y desactiva todas las demás
    public void cambiarPantallaRealidadAumentadaSalon()
    {
        panelSalon scriptPanelSalonUI = ObtenerDatosSalon.GetComponent<panelSalon>(); // Se obtiene el GameObject del script del panel salón UI
        StartCoroutine(scriptPanelSalonUI.CorrutinaObtenerDatos()); // Se activa la corrutina de obtener datos de la url
        // opcionCamara = 1; // Se establece la navegación a que entro por la cámara

        arCamera.SetActive(true); // Se activa la cámara
        // RequestCameraPermission(); // Solicitar permisos de la cámara al usuario
        pantallLogin.SetActive(false); // Se desactiva la pantalla de login
        pantallaPrincipal.SetActive(false); // Se desactiva la pantalla del menú principal
        panelBusqueda.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(true); // Se activa la pantalla de AR para los paneles de salones y profesores
        StartCoroutine(quitarPantallaUI()); // Se manda llamar al trigger desactivar la animación de panel realidad aumentada

        panel1SalonAR.SetActive(true); // Se activa la pantalla de realidad aumentada del salón
        panel2ProfesorAR.SetActive(false); // Se desactiva la pantalla de realidad aumentada del profesor
        panel1SalonUI.SetActive(true); // Se activa la pantalla de interfaz virtual del salón
        panel2ProfesorUI.SetActive(false); // Se desactiva la pantalla de interfaz virtual del profesor
    }

    // Función que activa la cámara, la interfaz de la realidad aumentada para el panel de profesores y la flecha de regreso, y desactiva todas las demás
    public void cambiarPantallaRealidadAumentadaProfesor()
    {
        panelProfesor scriptPanelProfesorUI = ObtenerDatosProfesor.GetComponent<panelProfesor>(); // Se obtiene el GameObject del script del panel profesor UI
        StartCoroutine(scriptPanelProfesorUI.CorrutinaObtenerDatos()); // Se activa la corrutina de obtener datos de la url
        // opcionCamara = 1; // Se establece la navegación a que entro por la cámara

        arCamera.SetActive(true); // Se activa la cámara
        // RequestCameraPermission(); // Solicitar permisos de la cámara al usuario
        pantallLogin.SetActive(false); // Se desactiva la pantalla de login
        pantallaPrincipal.SetActive(false); // Se desactiva la pantalla del menú principal
        panelBusqueda.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
        pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
        realidadAumentada.SetActive(true); // Se activa la pantalla de AR para los paneles de salones y profesores
        StartCoroutine(quitarPantallaUI()); // Se manda llamar al trigger desactivar la animación de panel realidad aumentada

        panel1SalonAR.SetActive(false); // Se desactiva la pantalla de realidad aumentada del salón
        panel2ProfesorAR.SetActive(true); // Se activa la pantalla de realidad aumentada del profesor
        panel1SalonUI.SetActive(false); // Se desactiva la pantalla de interfaz virtual del salón
        panel2ProfesorUI.SetActive(true); // Se activa la pantalla de interfaz virtual del profesor
    }

    // Función que activa la cámara, la interfaz UI de salones, y desactiva todas las demás
    public void cambiarPantallaVirtualUISalon()
    {
        Debug.Log(gameObject.name);
        contadorQuitarPanel = 0; // El contador del tiempo de la interfaz UI se restablece para empezar nuevamente
        panelSalon scriptPanelSalonUI = ObtenerDatosSalon.GetComponent<panelSalon>(); // Se obtiene el GameObject del script del panel salón UI
        StartCoroutine(scriptPanelSalonUI.CorrutinaObtenerDatos()); // Se activa la corrutina de obtener datos de la url
        opcionCamara = 2; // Se establece la navegación a que entro por la búsqueda

        panelBusqueda.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        arCamera.SetActive(true); // Se activa la cámara
        // RequestCameraPermission(); // Solicitar permisos de la cámara al usuario
        realidadAumentada.SetActive(true); // Se activa la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(true); // Se activa los paneles UI de salones y profesores

        panel1SalonAR.SetActive(true); // Se activa la pantalla de realidad aumentada del salón
        panel2ProfesorAR.SetActive(false); // Se desactiva la pantalla de realidad aumentada del profesor
        panel1SalonUI.SetActive(true); // Se activa la pantalla de interfaz virtual del salón
        panel2ProfesorUI.SetActive(false); // Se desactiva la pantalla de interfaz virtual del profesor
    }

    // Función que activa la cámara, la interfaz UI de profesores, y desactiva todas las demás
    public void cambiarPantallaVirtualUIProfesor()
    {
        contadorQuitarPanel = 0; // El contador del tiempo de la interfaz UI se restablece para empezar nuevamente
        panelProfesor scriptPanelProfesorUI = ObtenerDatosProfesor.GetComponent<panelProfesor>(); // Se obtiene el GameObject del script del panel profesor UI
        StartCoroutine(scriptPanelProfesorUI.CorrutinaObtenerDatos()); // Se activa la corrutina de obtener datos de la url
        opcionCamara = 2; // Se establece la navegación a que entro por la búsqueda

        panelBusqueda.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
        arCamera.SetActive(true); // Se activa la cámara
        // RequestCameraPermission(); // Solicitar permisos de la cámara al usuario
        realidadAumentada.SetActive(true); // Se activa la pantalla de AR para los paneles de salones y profesores
        virtualUI.SetActive(true); // Se activa los paneles UI de salones y profesores

        panel1SalonAR.SetActive(false); // Se desactiva la pantalla de realidad aumentada del salón
        panel2ProfesorAR.SetActive(true); // Se activa la pantalla de realidad aumentada del profesor
        panel1SalonUI.SetActive(false); // Se desactiva la pantalla de interfaz virtual del salón
        panel2ProfesorUI.SetActive(true); // Se activa la pantalla de interfaz virtual del profesor
    }

    // Función para cambiar al panel de la interfaz virtual, cuando desaparece el panel de realidad aumentada
    public void cambiarPantallaVirtualUI(){   
        // Se verifica que la cámara y la interfaz de la AR estén activadas
        if ((realidadAumentada.activeSelf == true) && (arCamera.activeSelf == true))
        {
            // StartCoroutine(quitarPantallaAR()); // Se manda llamar al trigger desactivar la animación de panel interfaz de usuario
            // Se verifica que panel estaba activado en la realidad aumentada cuando desaparece
            if(panel2ProfesorAR.activeSelf == true){
                cambiarPantallaVirtualUIProfesor(); // Cambiar al paner de UI de profesor
            }else if(panel1SalonAR.activeSelf == true){
                cambiarPantallaVirtualUISalon(); // Cambiar al panel de UI de salón
            }
        }
    }

    // Función que retrae la información de la API de inicio de sesión y la valida para redirigir al usuario a la aplicación
    public void IngresarAplicacion(){

        
        StartCoroutine(LoginPeticion(EntradaExpediente.text, EntradaContrasena.text));
    }

    // Función que manda llamar al coroutine de inicio de sesión    
    public IEnumerator LoginPeticion(string expediente, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("expediente", expediente);
        form.AddField("password", password);
       
        UnityWebRequest Peticion = UnityWebRequest.Post("http://148.220.52.101/api/portal/login/", form);
        yield return Peticion.SendWebRequest();

        // Debug.Log(Peticion.responseCode);
        if (Peticion.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Expediente o contraseña incorrectos");

        }
        else
        {
            // Debug.Log("FUNCIONA");
            pantallLogin.SetActive(false); // Se desactiva la pantalla de login
            pantallaPrincipal.SetActive(true); // Se activa la pantalla principal de la aplicación
            panelBusqueda.SetActive(false); // Se desactiva la pantalla de búsqueda de profesores y salones
            pantallaCroquis.SetActive(false); // Se desactiva a pantalla del croquis de la facultad
            pantallaCreditos.SetActive(false); // Se desactiva la pantalla de los créditos de la aplicación
            realidadAumentada.SetActive(false); // Se desactiva la pantalla de AR para los paneles de salones y profesores
            virtualUI.SetActive(false); // Se desactiva los paneles UI de salones y profesores
        }
    }

    // Función que redirige al usuario al usuario al portal de la facultad de informática
    public void IrPortalFacultad(){
        Application.OpenURL("http://portalinformatica.uaq.mx/portalInformatica/"); // Redirige a una URL
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

    // // Función que solicita permiso al usuario para acceder a la funcionalidad de la cámara
    // private void RequestCameraPermission()
    // {
    //     if (Permission.HasUserAuthorizedPermission(Permission.Camera))
    //     {
    //         // La aplicación ya tiene permisos de cámara, no se necesita solicitar permisos
    //         return;
    //     }

    //     // La aplicación no tiene permisos de cámara, solicita permisos
    //     Permission.RequestUserPermission(Permission.Camera);
    // }

    // Función que cambia el objeto del panel de realidad aumentada al nuevo target identificado
    public void cambiarPadrePanelesTarget()
    {
        // Pasar ID
        Debug.Log("El nuevo idSalon es " + idSalon);
        // Iniciar obtener Datos
        paneles.transform.parent = targetRecibido.transform; // Cambiar padre al nuevo ImageTarget enfocado 
        // paneles.transform.position = new Vector3(0,0,0);
        paneles.GetComponent<Canvas>().enabled = true;

        paneles.GetComponent<RectTransform>().localPosition = Vector3.zero; // Se mueve el panel al ImageTarget nuevo
        paneles.GetComponent<RectTransform>().localRotation = Quaternion.Euler(90f, 0f, 0f); // Se voltea el panel a la cámara
    }
}
