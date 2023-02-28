using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class panelSalon : MonoBehaviour
{
    // Los GameObject son los bloques de construcción fundamentales, pueden representar personajes, accesorios, escenarios y más

    // Datos del Salón en el AR
    public GameObject nombreProfesor; //GameObject NombreProfesor
    public GameObject materiaProfesor; // GameObject de la materia del profesor 
    public GameObject horarioProfesor; // GameObject del horario del profesor
    public GameObject grupoProfesor; // GameObject del grupo del profesor
    public GameObject edificioProfesor; // GameObject del edificio del profesor
    public GameObject salonProfesor; // GameObject del salon del profesor 
    public GameObject imagenProfesor; // GameObject de la imagen del profesor 
    // Datos del Salón en el UI
    public GameObject nombreProfesorUI; // GameObject de la interfaz nombre profesor
    public GameObject materiaProfesorUI; // GameObject de la interfaz materia profesor 
    public GameObject horarioProfesorUI; // GameObject de la interfaz horario profesor
    public GameObject grupoProfesorUI; // GameObject de la interfaz grupo profesor
    public GameObject edificioProfesorUI; // GameObject de la interfaz edificio profesor
    public GameObject salonProfesorUI; // GameObject de la interfaz salon profesor 
    public GameObject imagenProfesorUI; // GameObject de la interfaz imagen profesor

    private int idSalon = 0; // ID del salón que se muestra en el panel
    private int idProfesorEnSalon = 0; // ID del profesor que se encuentra en el ID del salón

    public GameObject cambioPantallas; // GameObject de donde se obtiene el MenuPrincipal
    
    public GameObject cargando;
    public GameObject error;
    public GameObject recargar;
    public GameObject cargandoUI;
    public GameObject errorUI;
    public GameObject recargarUI;

    // Agreaga la estructura a unity Inspector lo que le permite establecer los valores de estos campos en el editor de Unity
    [System.Serializable]
    public struct Profesor 
    {
        // Se declaran las variables de tipo estring para los datos del profesor
        public string name;
        public string id;
        public string status;
        public string species;
        public string gender;
        public string image;
    }
    // Permite establecer los valores de estos campos en el editor de Unity.
    [System.Serializable]
    public struct Salon 
    {
        // Se declaran las variables de tipo estring para los datos del Salon
        public string name;
        public string id;
        public string status;
    }

    public Profesor infoProfesor; // Se declara un objeto de tipo Profesor con su información
    public Salon infoSalon; // Se declara un objeto de tipo Salón con su información


    public void recargarSalon(){
        StartCoroutine(CorrutinaObtenerDatos());
    }
    // IEnumerator para obtener datos de una url
    public IEnumerator CorrutinaObtenerDatos()
    {   
        MenuPrincipal scriptCambioPantallas = cambioPantallas.GetComponent<MenuPrincipal>(); // Se obtiene el GameObject de MenuPrincipal, con sus atributos y métodos
        idSalon = scriptCambioPantallas.idSalon; // Se obtiene el ID del salón que el usuario selecciono para mostrar

        cargando.SetActive(true);
        error.SetActive(false);
        recargar.SetActive(false);
        cargandoUI.SetActive(true);
        errorUI.SetActive(false);
        recargarUI.SetActive(false);

        string url; // Se declara una varible de tipo string para la url
        url = "rickandmortyapi.com/api/character/" + idSalon.ToString(); // Se forma la url para obtener datos del salón seleccionado por el usuario
        UnityWebRequest Peticion = UnityWebRequest.Get(url); // Realizar petición con la url formada
        yield return Peticion.SendWebRequest(); // Pausa la ejecución hasta que se complete la solicitud
        
        // Si isNetworkError y ishttpError son falsas, la peticion se realiza correctamente
        if(!Peticion.isNetworkError && !Peticion.isHttpError){ //Probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError
            // Peticion.downloadHandler.textpropiedad proporciona la cadena JSON, que contiene el cuerpo de la respuesta como una cadena
            infoSalon = JsonUtility.FromJson<Salon>(Peticion.downloadHandler.text); // El JsonUtility.FromJson método de Unity para analizar los datos de respuesta del Peticion objeto en un Salon objeto
            
            // Salón AR
            // Muestra el texto en un elemento de la interfaz de usuario
            TMP_Text edificio = edificioProfesor.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de edificio profesor
            edificio.text = infoSalon.status; // Una vez que accede puede cambiar el valor por medio de la propiedad text
            TMP_Text salon = salonProfesor.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de salon profesor
            salon.text = infoSalon.id; // Una vez que accede puede cambiar el valor por medio de la propiedad text

            // Salón UI
            TMP_Text edificioUI = edificioProfesorUI.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de la interfaz edificioProfesorUI
            edificioUI.text = infoSalon.status; // Una vez que accede puede cambiar el valor por medio de la propiedad text
            TMP_Text salonUI = salonProfesorUI.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de la interfaz salonUI
            salonUI.text =  infoSalon.id; // Una vez que accede puede cambiar el valor por medio de la propiedad text
            
            // Obtener informacion del profesor que se encuentra en el salon
            idProfesorEnSalon = idSalon; //TEMPORALMENTE ES EL MISMO ID, CAMBIARA CUANDO TENGAMOS API AL ID REAL
            
            Debug.Log("Profesor id " + idProfesorEnSalon); // Debug.Log imprime en la consola id del profesor
            StartCoroutine(ObtenerDatosProfesor()); // Se inicia la CorrutinaObtenerDatos() la cual se ejecuta simultaneamente con el resto del código
            cargando.SetActive(false); // Se establece la propiedad Active del panel Cargando objeto del juego en false, lo que deshabilitará u ocultará el GameObject
            cargandoUI.SetActive(false);
        }else{
            Debug.LogWarning("Error en la peticion"); // En caso de haber un error en la petición se imprime un mensaje 
            cargando.SetActive(false);
            error.SetActive(true);
            recargar.SetActive(true);
            cargandoUI.SetActive(false);
            errorUI.SetActive(true);
            recargarUI.SetActive(true);
        }             
    }

    // Función para pasar al siguiente ID del profesor
    public void SiguienteProfesor(){
        idProfesorEnSalon = idProfesorEnSalon + 1; //TEMPORALMENTE SE SUMA 1, DESPUES API TENDRA EL ID DEL SIG PROFESOR
        StartCoroutine(ObtenerDatosProfesor()); // Se inicia la CorrutinaObtenerDatos() la cual se ejecuta simultaneamente con el resto del código
    }

    // Función para volver al anterior ID del profesor
    public void AnteriorProfesor(){
        idProfesorEnSalon = idProfesorEnSalon - 1; //TEMPORALMENTE SE SUMA 1, DESPUES API TENDRA EL ID DEL SIG PROFESOR
        StartCoroutine(ObtenerDatosProfesor()); // Se inicia la CorrutinaObtenerDatos() la cual se ejecuta simultaneamente con el resto del código
    }
    
    // IEnumerator para obtener datos de una url
    public IEnumerator ObtenerDatosProfesor()
    {   
        cargando.SetActive(true);
        error.SetActive(false);
        recargar.SetActive(false);     
        cargandoUI.SetActive(true);
        errorUI.SetActive(false);
        recargarUI.SetActive(false);     
        
        string url; // Se declara una varible de tipo string para la url
        url = "rickandmortyapi.com/api/character/" + idProfesorEnSalon.ToString(); // Se estructura la url donde se saca la información según el ID
        UnityWebRequest Peticion = UnityWebRequest.Get(url); // Realizar petición
        yield return Peticion.SendWebRequest(); // Declaración que le dice al código que pause la ejecución hasta que se complete la solicitud
        
        if(!Peticion.isNetworkError && !Peticion.isHttpError){ //Probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
            // Peticion.downloadHandler.textpropiedad proporciona la cadena JSON, que contiene el cuerpo de la respuesta como una cadena
            infoProfesor = JsonUtility.FromJson<Profesor>(Peticion.downloadHandler.text); // JsonUtility.FromJson método de Unity para analizar los datos de respuesta del Peticion objeto en un InformacionProfesor objeto según el ID
            
            // Salón AR
            TMP_Text nombre = nombreProfesor.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text del nombre profesor
            nombre.text = infoProfesor.name; // Una vez que accede puede cambiar el valor de la propiedad name por medio de text
            TMP_Text materia = materiaProfesor.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de la materia profesor
            materia.text = infoProfesor.status; // Una vez que accede puede cambiar el valor de la propiedad status por medio de text 
            TMP_Text grupo = grupoProfesor.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text del grupo profesor
            grupo.text = infoProfesor.gender; // Una vez que accede puede cambiar el valor de la propiedad gender por medio de text
            TMP_Text horario = horarioProfesor.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de la materia profesor
            horario.text = infoProfesor.name; // Una vez que accede puede cambiar el valor de la propiedad name por medio de text
            StartCoroutine(cargarImagenProfesor(infoProfesor.image, imagenProfesor)); // Inicia una corrutina cargarImagenProfesor, para cargar y asignar una imagen a imagenProfesor
            
            // Salón UI
            TMP_Text nombreUI = nombreProfesorUI.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de la interfaz nombre profesor
            nombreUI.text = infoProfesor.name; // Una vez que accede puede cambiar el valor de la propiedad name por medio de text
            TMP_Text materiaUI = materiaProfesorUI.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de la interfaz materia profesor
            materiaUI.text = infoProfesor.status; // Una vez que accede puede cambiar el valor de la propiedad status por medio de text
            TMP_Text grupoUI = grupoProfesorUI.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de lainterfaz grupo profesor
            grupoUI.text = infoProfesor.gender; // Una vez que accede puede cambiar el valor de la propiedad gender por medio de text
            TMP_Text horarioUI = horarioProfesorUI.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text lainterfaz horario profesor   
            horarioUI.text = infoProfesor.name; // Una vez que accede puede cambiar el valor de la propiedad name por medio de text
            StartCoroutine(cargarImagenProfesor(infoProfesor.image, imagenProfesorUI)); // Inicia una cortina cargarImagenProfesor, para cargar y asignar una imagen a imagenProfesorUI
            cargando.SetActive(false); // Se establece la propiedad Active del panel Cargando objeto del juego en true, lo que desahabilirara el GameObject
            cargandoUI.SetActive(false);
        }else{
            Debug.LogWarning("Error en la peticion"); // En caso de un error imprime un mensaje de error
            cargando.SetActive(false);
            error.SetActive(true);
            recargar.SetActive(true);
            cargandoUI.SetActive(false);
            errorUI.SetActive(true);
            recargarUI.SetActive(true);
        }             
    }

    // Recibe como parametros MediaUrl y el GameObjet imagenProfesor
    public IEnumerator cargarImagenProfesor(string MediaUrl, GameObject imagenProfesor)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl); // Se recibe una respuesta como imagen del servidor por medio de MediaUrl a traves de GetTexture
        yield return request.SendWebRequest(); // Pausa la ejecución hasta que se complete la solicitud

        // Si isNetworkError y ishttpError son verdaderas, no se realiza la petición
        if(request.isNetworkError || request.isHttpError){
            Debug.Log(request.error); // Imprime un mensaje de error en la consola
        }else{
            // Se desacargan las imagenes desde el servidor por medio de DownloadHandlerTexture
            Texture myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture; // Texture devuelve la textura que se ha descargado
            RawImage imagenRequestProfesor = imagenProfesor.GetComponent<RawImage>(); // RawImage componente se recupera y se almacena en la variable imagenRequestProfesor, que se puede usar para manipular la apariencia
            imagenRequestProfesor.texture = myTexture; // La propiedad texture de un RawImagecomponente se usa para establecer la textura que se muestra en el lienzo 2D
        }            
    }
}
