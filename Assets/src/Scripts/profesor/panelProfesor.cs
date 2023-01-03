using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class panelProfesor : MonoBehaviour
{
    // Los GameObject son los bloques de construcción fundamentales, pueden representar personajes, accesorios, escenarios y más.
    // Datos del Profesor en el AR
    public GameObject especializacionNombreProfesor; // GameObject de la especializacion del profesor
    public GameObject areaConocimiento; // GameObject del area de conocimeinto del prefesor
    public GameObject curriculum; // GameObject del curriculum del profesor
    public GameObject cubiculo; // GameObject del cubiculo del profesor
    public GameObject imagenProfesor; // GameObject de la imagen profesor
    // Datos del Profesor en el UI
    public GameObject especializacionNombreProfesorUI; // GameObject de la interfaz especializacion 
    public GameObject areaConocimientoUI; // GameObject de la interfaz area de conocimiento
    public GameObject curriculumUI; // GameObject de la interfaz del curriculum
    public GameObject cubiculoUI; // GameObject de la interfaz del cubiculo
    public GameObject imagenProfesorUI; // GameObject de la interfaz del profesor

    private int idProfesor = 1; // ID del profesor que se muestra en el panel, por default es el primero
    public GameObject cambioPantallas; // GameObject de donde se obtiene el MenuPrincipal

    // Agreaga la estructura a unity Inspector, lo que le permite establecer los valores de estos campos en el editor de Unity
    [System.Serializable]
    public struct InformacionProfesor 
    {
        // Se declaran las variables de tipo estring para los datos de InformacionProfesor
        public string name; // Nombre del profesor
        public string id; // ID del profesor
        public string status; 
        public string species; 
        public string gender;
        public string image; // Imagen del profesor
    }

    public InformacionProfesor infoExtraProfesor; // Se declara un objeto del tipo InformacionProfesor

    // IEnumerator para obtener datos de una url
    public IEnumerator CorrutinaObtenerDatos()
    {   
        MenuPrincipal scriptcambioPantallas = cambioPantallas.GetComponent<MenuPrincipal>(); // Se obtiene el GameObject de MenuPrincipal, con sus atributos y métodos
        idProfesor = scriptcambioPantallas.idProfesor; // Se obtiene el ID del profesor que el usuario selecciono para mostrar
        
        string url; // Se declara una varible de tipo string para la url
        url = "rickandmortyapi.com/api/character/" + idProfesor.ToString(); // Se estructura la url donde se saca la información según el ID
        UnityWebRequest Peticion = UnityWebRequest.Get(url); // Realizar petición de la url
        yield return Peticion.SendWebRequest(); // Declaración que le dice al código que pause la ejecución hasta que se complete la solicitud
        
        // Si isNetworkError y ishttpError son falsas, la peticion se realiza correctamente
        if(!Peticion.isNetworkError && !Peticion.isHttpError){ //probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
            // Peticion.downloadHandler.textpropiedad proporciona la cadena JSON, que contiene el cuerpo de la respuesta como una cadena
            infoExtraProfesor = JsonUtility.FromJson<InformacionProfesor>(Peticion.downloadHandler.text); // JsonUtility.FromJson método de Unity para analizar los datos de respuesta del Peticion objeto en un InformacionProfesor objeto
                        
            // Profesor AR
            TMP_Text especializacion = especializacionNombreProfesor.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de especializacion profesor
            especializacion.text = infoExtraProfesor.name + " / " + infoExtraProfesor.status; // Una vez que accede puede cambiar el valor por medio de la propiedad text
            TMP_Text area = areaConocimiento.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de area de conocimiento
            area.text = infoExtraProfesor.species; // Una vez que accede puede cambiar el valor por medio de la propiedad text
            TMP_Text curriculumTexto = curriculum.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de curriculum 
            curriculumTexto.text = infoExtraProfesor.gender; // Una vez que accede puede cambiar el valor por medio de la propiedad text
            TMP_Text edificio = cubiculo.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de cubiculo 
            edificio.text = infoExtraProfesor.species; // Una vez que accede puede cambiar el valor por medio de la propiedad text
            StartCoroutine(cargarImagenProfesor(infoExtraProfesor.image, imagenProfesor)); // Se inicia la corrutina para cambiar la imagen del profesor en el panel AR

            // Profesor UI
            TMP_Text especializacionUI = especializacionNombreProfesorUI.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de  especializacionNombreProfesorUI
            especializacionUI.text = infoExtraProfesor.name + " / " + infoExtraProfesor.status; // Una vez que accede puede cambiar el valor por medio de la propiedad text
            TMP_Text areaUI = areaConocimientoUI.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de areaConocimientoUI
            areaUI.text = infoExtraProfesor.species; // Una vez que accede puede cambiar el valor por medio de la propiedad text
            TMP_Text curriculumTextoUI = curriculumUI.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de curriculumUI 
            curriculumTextoUI.text = infoExtraProfesor.gender; // Una vez que accede puede cambiar el valor por medio de la propiedad text
            TMP_Text edificioUI = cubiculoUI.GetComponent<TMP_Text>(); // GetComponent accede al componente del objeto TMP_Text de cubiculoUI
            edificioUI.text = infoExtraProfesor.species; // Una vez que accede puede cambiar el valor por medio de la propiedad text
            StartCoroutine(cargarImagenProfesor(infoExtraProfesor.image, imagenProfesorUI)); // Se inicia la corrutina para cambiar la imagen del profesor en la interfaz UI
        }else{
            Debug.LogWarning("Error en la peticion"); // En caso de un error imprime un mensaje de error 
            //Recargar.SetActive(true);
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
