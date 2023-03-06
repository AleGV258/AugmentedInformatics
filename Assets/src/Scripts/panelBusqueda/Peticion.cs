using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

/* Script de petición permite realizar, dentro de nuestro panel, busquedas de profesores, salones */
public class Peticion : MonoBehaviour
{
    [System.Serializable]
    public struct ListaProfesores // Estructura de la lista de profesores    
    {
        // Aquí se definen los elementos de la estructura de la lista de profesores
        [System.Serializable]
        public struct resultado{ // Se crea una estructura de resultado la cual almacenara los datos a mostrar de los profesores
            public string name; // Variable para almacenar el dato de nombre de la estructura de resultado
            public string url; // Variable para almacenar el dato de URL de la estructura de resultado
        }
        public string count; // Variable de la estructura de profesores para mantener un conteo !A REVISAR!
        public string next; // Variable de profesores para almacenar el siguiente profesor
        public string previous; // Variable de profesores para almacenar eL profesor anterior
        public resultado[] results; // Arreglo de la lista de profesores que almacena los resultados o profesores.
    }
    [System.Serializable]
    public struct ListaSalones // Estructura de lista de salones
    {
        [System.Serializable]
        public struct resultado { // Estructura de resultado que almacena los datos de cada salón
            public string name; // Variable por resultado, es decir salón, que almacena el nombre de dicho salón
            public string url;  // Variable por resultado, es decir salón, que almacena el URL de dicho salón
        }
        public string count; // Variable de la lista de salones que almacena el conteo de cada salón
        public string next; // Variable que almacena el siguiente salón
        public string previous; // Variable que almacena el salón anterior
        public resultado[] results; // Arreglo de la lista de salones que almacena los resultados o salones.
    }

    public ListaProfesores listaRecibidaProfesores; // Lista donde se almacenan los profesores que se reciben
    public TMP_InputField EntradaBuscador; // Variable para el ingreso del profesor o salón a buscar
    public GameObject ObjProfesor; // GameObject de un objeto profesor
    public GameObject ObjLista; // GameObject de un objeto de lista
    public GameObject Selector; // GameObject de un objecto selector
    public GameObject ObjSalon; // GameObject de un objeto de salón
    public ListaSalones listaRecibidaSalones; // Lista donde se almacenan los profesores que se reciben
    public GameObject ObjInputPlaceholder; // Placeholder del input donde el usuario busca salones o maestros
    public GameObject ObjTitulo; // GameObject del titulo de la interfaz
    public GameObject cambioPantallas; // GameObject para el cambio de interfaces o pantallas
    public GameObject Recargar; // GameObject de un objecto para recargar la interfaz
    public GameObject Cargando;
    public GameObject Error;

    // Función que se ejecuta al iniciar la aplicación y en su primer frame
    void Start () {
        StartCoroutine(CorrutinaObtenerDatos("")); // Obtener el listado los profesores
        Recargar.SetActive(false);
        Cargando.SetActive(false);
        Error.SetActive(false);
	}    

    // Función que ejecuta la corrutina de obtener datos
    public void ObtenerDatos()
    {
        Cargando.SetActive(true);
        if(EntradaBuscador.text == ""){
            StartCoroutine(CorrutinaObtenerDatos(""));// Obtener todos los profesores
        }else{
            StartCoroutine(CorrutinaObtenerDatos(EntradaBuscador.text)); // Obtener profesor por búsqueda
        }
    }
    
    // IEnumerator para obtener datos de una url
    private IEnumerator CorrutinaObtenerDatos(string busqueda) // Método para obtener profesor/es por búsqueda
    {
        // Recargar.SetActive(false); // Se deshabilita el objeto de recargar

        // Ciclo que destruye los objetos creados con anterioridad al obtener nuevos datos
        for (int i = ObjLista.transform.childCount-1; i >= 0; i--) {
            DestroyImmediate(ObjLista.transform.GetChild(i).gameObject); // El ciclo es un destructor de todos los objetos regresados por la API, para la obtención de nuevos objetos
        }
        int opcionSelector = Selector.GetComponent<TMP_Dropdown>().value; // Se pasa el valor del objecto seleccionado por el usuario, en este caso el ID del salón o profesor
        
        string url; // Variable que almacena la url
        
         // Opción de profesores
        if(opcionSelector == 0){
            TMP_Text OIP = ObjInputPlaceholder.GetComponent<TMP_Text>(); // Gameobject de ingreso de busqueda de profesor
            OIP.text = "Buscar un profesor ... "; // Texto para la interfaz que indica la busqueda de un profesor
            
            TMP_Text titulo = ObjTitulo.GetComponent<TMP_Text>(); // Gameobject del titulo de la interfaz
            titulo.text = "Profesores "; // Se define el texto del titulo de la interfaz como 'Profesores'
            
            if(busqueda == ""){ // Condición que verifica si busqueda no contiene datos
                url = "https://pokeapi.co/api/v2/pokemon?limit=" + "30"; // Si no, regresa todos los profesores
            }else{
                url = "https://pokeapi.co/api/v2/pokemon?limit=" + busqueda; // Si contiene un dato realiza la busqueda filtrada del profesor
            }
            
            UnityWebRequest Peticion = UnityWebRequest.Get(url); // Realizar petición
            yield return Peticion.SendWebRequest(); // Devuelve el resultado de la petición realizada
            if(!Peticion.isNetworkError && !Peticion.isHttpError){ // probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
                listaRecibidaProfesores = JsonUtility.FromJson<ListaProfesores>(Peticion.downloadHandler.text); // Se almacena en listaRecibidaProfesores, la lista que entrega el resultado de la petición
                //  Debug.Log(JsonUtility.ToJson(listaRecibidaProfesores));
                //  Debug.Log(listaRecibidaProfesores.results.Length);
                
                for(int i=0; i<listaRecibidaProfesores.results.Length; i++){ // Ciclo que recorre la lista recibida de profesores  de la petición
                    // Debug.Log(listaRecibidaProfesores.results[i].name);
                    GameObject profe = Instantiate(ObjProfesor, new Vector3(150, 350,0), Quaternion.identity, ObjLista.transform); // Se inicia el Gameobject de profesor con sus respectivos campos
                    
                    GameObject imagenProfesor = profe.transform.GetChild(0).gameObject; // Imagen profesor
                    GameObject nombreProfesor = profe.transform.GetChild(1).gameObject; // Nombre profesor
                    GameObject especializacionProfesor = profe.transform.GetChild(2).gameObject; // Especializacion profesor
                    GameObject cubiculoProfesor = profe.transform.GetChild(3).gameObject; // Especializacion profesor
                    // Faltan componentes para cada profesor

                    StartCoroutine(cargarImagenProfesor("https://thumbs.dreamstime.com/b/icono-del-usuario-106603539.jpg", imagenProfesor)); // Realiza la carga de la imagen del profesor

                    TMP_Text np = nombreProfesor.GetComponent<TMP_Text>(); // Se inicializa el nombre del profesor en TMP_text np
                    np.text = listaRecibidaProfesores.results[i].name; // Se almacena el nombre del profesor en np.text
                    profe.transform.SetParent(ObjLista.transform, false); // Indica que el transform del objeto "profe" adquirira las propiedades transform de un objeto nuevo y se volvera hijo de objLista 
                    
                    TMP_Text ep = especializacionProfesor.GetComponent<TMP_Text>(); // Se inicializa en ep el dato de especialización del profesor
                    ep.text = "Especialización del profesor"; // Se almacena en ep.text "Especialización del profesor"

                    TMP_Text cp = cubiculoProfesor.GetComponent<TMP_Text>(); // Se inicializa cp para almacenar el cubiculo del profesor
                    cp.text = "C09"; // Se define el cubiculo de profesor

                    // Id del profesor dentro del objeto profe
                    profeObjeto profesorID = profe.GetComponent<profeObjeto>(); // Se inicializa profesorID para almacenar los id de profesores
                    profesorID.idProfesor = i+1; // cambiar por el valor real de ID
                    profesorID.cambioPantallas = cambioPantallas;
                }   
                Cargando.SetActive(false);                     
            }else{ // Si no se cumple la condicion, es decir, ocurre un error
                Debug.LogWarning("Error en la peticion"); // Se devuelve un mensaje de error
                Error.SetActive(true);
                Recargar.SetActive(true); // Recargar se activa
            }   
        }else{
            
            // Opcion de salones

            Cargando.SetActive(true);

            TMP_Text OIP = ObjInputPlaceholder.GetComponent<TMP_Text>(); // Se define el objeto de busqueda de salón
            OIP.text = "Buscar un salón ... "; // Se coloca un texto en OIP.text para que se muestre el mensaje de "Buscar un salón ... "

            TMP_Text titulo = ObjTitulo.GetComponent<TMP_Text>(); // Se define el objeto del titulo 
            titulo.text = "Salones "; // Se coloca el texto "Salones " en titulo.text

            if(busqueda == ""){ // Se evalua que la busqueda no contenga datos
                url = "https://pokeapi.co/api/v2/pokemon?limit=" + "30"; // Si no contiene se devuelven todos los salones
            }else{
                url = "https://pokeapi.co/api/v2/pokemon?limit=" + busqueda; // Si contiene se realiza una busqueda filtrada del salon
            }
            
            UnityWebRequest Peticion = UnityWebRequest.Get(url); // Realizar petición
            yield return Peticion.SendWebRequest(); // Devuelve el resultado de la petición
            
            if(!Peticion.isNetworkError && !Peticion.isHttpError){ // probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
                listaRecibidaSalones = JsonUtility.FromJson<ListaSalones>(Peticion.downloadHandler.text); // Si se cumple la condición se instancia una lista de los salones recibidos
                //  Debug.Log(JsonUtility.ToJson(listaRecibidaSalones));
                //  Debug.Log(listaRecibidaSalones.results.Length);                
                
                for(int i= 0; i< listaRecibidaSalones.results.Length; i++){ // Ciclo para recorrer la lista de salones recibidos
                    // Debug.Log(listaRecibidaSalones.results[i].name);
                    GameObject salon = Instantiate(ObjSalon, new Vector3(150, 350,0), Quaternion.identity, ObjLista.transform); // Gamobjecto de salon se inicia con un objeto salon, un vector, una identidad y un objeto ObjLista.transform
                    
                    GameObject ImagenSalon = salon.transform.GetChild(0).gameObject; // Gameobject que guardara la imagen del salón
                    GameObject nombreSalonPanel = ImagenSalon.transform.GetChild(0).gameObject; // Gameobject que almacenara el panel nombre del salón

                    GameObject nombreSalon = salon.transform.GetChild(1).gameObject; // Gameobject que almacena el nombre de salón
                    GameObject estadoSalon = salon.transform.GetChild(2).gameObject; // Gameobject que almacena el estado del salón
                    GameObject ubicacionSalon = salon.transform.GetChild(3).gameObject; // Gameobject que almacena la ubicación del salón
                    // Faltan componentes para cada salon                   

                    TMP_Text nsp = nombreSalonPanel.GetComponent<TMP_Text>(); // Se inicializa nsp para que almacene un panel de nombre de salon, es decir, la imagen
                    nsp.text = listaRecibidaSalones.results[i].name;  // Se almacena en nsp.text el nombre del panel del salón
                    
                    TMP_Text ns = nombreSalon.GetComponent<TMP_Text>(); // Se inicializa en ns para que almacene el nombre del salón
                    ns.text = listaRecibidaSalones.results[i].name;  // Se almacena en ns.text el nombre del salón
                    
                    TMP_Text es = estadoSalon.GetComponent<TMP_Text>(); // Se inicializa es para que almacene el cambio de estado de salón
                    es.text = "Estado Cambiado"; // Se le coloca un texto de "Estado Cambiado"

                    TMP_Text us = ubicacionSalon.GetComponent<TMP_Text>(); // Se inicializa us para que almacene la ubicación de salón
                    us.text = "Ubicacion Cambiada"; // Se le coloca el texto de "Ubicación Cambiada"
                    
                    salon.transform.SetParent(ObjLista.transform); // Indica que el transform del objeto "salon" adquirira las propiedades transform de un objeto nuevo y se volvera hijo de objLista
                    
                    // Id del Salon dentro del objeto salon
                    salonObjeto scriptSalonObjeto = salon.GetComponent<salonObjeto>(); // Se inicializa scriptSalonObjeto para que almacene un id del salón
                    scriptSalonObjeto.idSalon = i+1; // cambiar por el valor real de ID
                    scriptSalonObjeto.cambioPantallas = cambioPantallas; // Cambia la pantalla
                }   

                Cargando.SetActive(false);                     
                
            }else{ // Si no, ocurrió un error
                Debug.LogWarning("Error en la peticion"); // Mensaje de de error que dice "Error en la petición"
                Error.SetActive(true); // Error se activa
                Recargar.SetActive(true); // Recargar se activa
            }   
        }
        
    }

    public IEnumerator cargarImagenProfesor(string MediaUrl, GameObject imagenProfesor) // Método para cargar la imagen de profesor
    {   
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl); // En request se almacena una petición de la textura de MediaUrl
        yield return request.SendWebRequest(); // Devuelve el resultado de la petición

        if(request.isNetworkError || request.isHttpError){ // Evaluá si ocurrió un error
            Debug.Log(request.error); // Si ocurrió, devuelve el error
        }else{ // Si no ocurrió
            Texture myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture; // En myTexture se almacena la textura de request.downloadHandler.texture
            RawImage imagenRequestProfesor = imagenProfesor.GetComponent<RawImage>(); // Se inicializa un RawImage que almacene el componente de imagen del profesor
            imagenRequestProfesor.texture = myTexture; // Se coloca en imagenRequestProfesor.texture la textura de myTexture
        }            
    }
    public void MetodoRecargar(){
        Recargar.SetActive(false);
        Error.SetActive(false);
        ObtenerDatos();
    }
}
