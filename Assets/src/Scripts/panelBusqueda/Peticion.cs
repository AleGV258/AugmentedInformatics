using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

/* Script de petición permite realizar, dentro de nuestro panel, busquedas de profesores, salones */
public class Peticion : MonoBehaviour
{
    // Atributos de los profesores
    [System.Serializable]
    public class ListaProfesores // Estructura de la lista de profesores    
    {
        // Aquí se definen los elementos de la estructura de la lista de profesores
        public string first_name; // Nombre/s del profesor
        public string last_name; // Apellidos del profesor
        public string email; // Correo electrónico del profesor
    }
    [System.Serializable]
    public class ProfesoresAPI
    {
        public List<ListaProfesores> dataProfesor;
    }

    // Atributos de los salones
    [System.Serializable]
    public class ListaSalones // Estructura de lista de salones
    {
        // Aquí se definen los elementos de la estructura de la lista de salones
        public string id; // ID de los salón
        public string aula_clave; // Clave del salón
        public string edificio; // Edificio donde se encuentra eñ salón
        public string aula_nombre; // Nombre del salón
        public bool activo; // Saber si el salón esta usable o no
    }
    [System.Serializable]
    public class SalonesAPI
    {
        public List<ListaSalones> dataSalon;
    }

    public ProfesoresAPI listaRecibidaProfesores; // Lista donde se almacenan los profesores que se reciben
    public SalonesAPI listaRecibidaSalones; // Lista donde se almacenan los salones que se reciben
    public TMP_InputField EntradaBuscador; // Variable para el ingreso del profesor o salón a buscar
    public GameObject ObjProfesor; // GameObject de un objeto profesor
    public GameObject ObjLista; // GameObject de un objeto de lista
    public GameObject Selector; // GameObject de un objecto selector
    public GameObject ObjSalon; // GameObject de un objeto de salón
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
        Cargando.SetActive(true);
        Error.SetActive(false);
	}    

    // Función que ejecuta la corrutina de obtener datos
    public void ObtenerDatos()
    {
        Cargando.SetActive(true); // Se habilita el objeto de recargar
        if(EntradaBuscador.text == ""){
            StartCoroutine(CorrutinaObtenerDatos("")); // Obtener todos los profesores
        }else{
            StartCoroutine(CorrutinaObtenerDatos(EntradaBuscador.text)); // Obtener profesor por búsqueda
        }
    }
    
    // IEnumerator para obtener datos de una url
    private IEnumerator CorrutinaObtenerDatos(string busqueda) // Método para obtener profesor/es por búsqueda
    {
        // Ciclo que destruye los objetos creados con anterioridad al obtener nuevos datos
        for (int i = ObjLista.transform.childCount-1; i >= 0; i--) {
            DestroyImmediate(ObjLista.transform.GetChild(i).gameObject); // El ciclo es un destructor de todos los objetos regresados por la API, para la obtención de nuevos objetos
        }
        int opcionSelector = Selector.GetComponent<TMP_Dropdown>().value; // Se pasa el valor del objecto seleccionado por el usuario, en este caso el ID del salón o profesor
        
        CultureInfo cultura = new CultureInfo("es-ES"); // Instancia de idioma español para la capitalización de strings
        string url; // Variable que almacena la url
        
        if(opcionSelector == 0){
            // Opción de profesores
            Cargando.SetActive(true); // Se habilita el objeto de recargar

            TMP_Text OIP = ObjInputPlaceholder.GetComponent<TMP_Text>(); // Gameobject de ingreso de busqueda de profesor
            OIP.text = "Buscar un profesor ... "; // Texto para la interfaz que indica la busqueda de un profesor
            
            TMP_Text titulo = ObjTitulo.GetComponent<TMP_Text>(); // Gameobject del titulo de la interfaz
            titulo.text = "Profesores "; // Se define el texto del titulo de la interfaz como 'Profesores'

            MenuPrincipal scriptCambioPantallas = cambioPantallas.GetComponent<MenuPrincipal>(); // Se obtiene el script de MenuPrincipal
            url = scriptCambioPantallas.API + "/maestros"; // Endpoint de donde se recaban los datos de la API de profesores
            
            UnityWebRequest Peticion = UnityWebRequest.Get(url); // Realizar petición
            yield return Peticion.SendWebRequest(); // Devuelve el resultado de la petición realizada

            if(!Peticion.isNetworkError && !Peticion.isHttpError){ // probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError
            
                listaRecibidaProfesores = JsonUtility.FromJson<ProfesoresAPI>("{\"dataProfesor\":" + Peticion.downloadHandler.text + "}"); // Se almacena en listaRecibidaProfesores, la lista que entrega el resultado de la petición

                for(int i = 1; i < listaRecibidaProfesores.dataProfesor.Count; i++){ // Ciclo que recorre la lista recibida de profesores de la petición

                    string nombreCompleto = cultura.TextInfo.ToTitleCase(listaRecibidaProfesores.dataProfesor[i].first_name.ToLower() + " " + listaRecibidaProfesores.dataProfesor[i].last_name.ToLower()); // Se almacena el nombre del profesor

                    if((nombreCompleto.ToUpper()).IndexOf(busqueda.ToUpper()) >= 0){ // Condicional que únicamente regresa la búsqueda introducida
                        GameObject profe = Instantiate(ObjProfesor, new Vector3(150, 350,0), Quaternion.identity, ObjLista.transform); // Se inicia el Gameobject de profesor con sus respectivos campos
                        
                        GameObject imagenProfesor = profe.transform.GetChild(0).gameObject; // Imagen profesor
                        GameObject nombreProfesor = profe.transform.GetChild(1).gameObject; // Nombre profesor
                        GameObject especializacionProfesor = profe.transform.GetChild(2).gameObject; // Especializacion profesor
                        GameObject cubiculoProfesor = profe.transform.GetChild(3).gameObject; // Especializacion profesor
                        // Faltan componentes para cada profesor
        
                        StartCoroutine(cargarImagenProfesor("https://thumbs.dreamstime.com/b/icono-del-usuario-106603539.jpg", imagenProfesor)); // Realiza la carga de la imagen del profesor

                        TMP_Text np = nombreProfesor.GetComponent<TMP_Text>(); // Se inicializa el nombre del profesor en TMP_text np
                        np.text = nombreCompleto; // Se almacena el nombre del profesor en np.text
                        profe.transform.SetParent(ObjLista.transform, false); // Indica que el transform del objeto "profe" adquirira las propiedades transform de un objeto nuevo y se volvera hijo de objLista 
                        
                        TMP_Text ep = especializacionProfesor.GetComponent<TMP_Text>(); // Se inicializa en ep el dato de especialización del profesor
                        ep.text = "Especialización del profesor"; // Se almacena en ep.text "Especialización del profesor"

                        TMP_Text cp = cubiculoProfesor.GetComponent<TMP_Text>(); // Se inicializa cp para almacenar el cubiculo del profesor
                        cp.text = "C09"; // Se define el cubiculo de profesor

                        // Id del profesor dentro del objeto profe
                        profeObjeto profesorID = profe.GetComponent<profeObjeto>(); // Se inicializa profesorID para almacenar los id de profesores
                        profesorID.idProfesor = i + 1; // cambiar por el valor real de ID
                        profesorID.cambioPantallas = cambioPantallas;
                    }
                }   
                Cargando.SetActive(false);

            }else{ // Si no se cumple la condicion, es decir, ocurre un error
                Debug.LogWarning("Error en la peticion"); // Se devuelve un mensaje de error
                Error.SetActive(true);
                Recargar.SetActive(true); // Recargar se activa
                Cargando.SetActive(false);  
            }   
        }else{
            // Opcion de salones
            Cargando.SetActive(true);

            TMP_Text OIP = ObjInputPlaceholder.GetComponent<TMP_Text>(); // Se define el objeto de busqueda de salón
            OIP.text = "Buscar un salón ... "; // Se coloca un texto en OIP.text para que se muestre el mensaje de "Buscar un salón ... "

            TMP_Text titulo = ObjTitulo.GetComponent<TMP_Text>(); // Se define el objeto del titulo 
            titulo.text = "Salones "; // Se coloca el texto "Salones " en titulo.text

            MenuPrincipal scriptCambioPantallas = cambioPantallas.GetComponent<MenuPrincipal>(); // Se obtiene el script de MenuPrincipal
            url = scriptCambioPantallas.API + "/aulas";  // Endpoint de donde se recaban los datos de la API de aulas
            
            UnityWebRequest Peticion = UnityWebRequest.Get(url); // Realizar petición
            yield return Peticion.SendWebRequest(); // Devuelve el resultado de la petición
            
            if(!Peticion.isNetworkError && !Peticion.isHttpError){ // probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError

                listaRecibidaSalones = JsonUtility.FromJson<SalonesAPI>("{\"dataSalon\":" + Peticion.downloadHandler.text + "}"); // Se almacena en listaRecibidaProfesores, la lista que entrega el resultado de la petición  

                for(int i = 0; i < listaRecibidaSalones.dataSalon.Count; i++){ // Ciclo para recorrer la lista de salones recibidos
                    if((listaRecibidaSalones.dataSalon[i].aula_nombre.ToUpper()).IndexOf(busqueda.ToUpper()) >= 0){ // Condicional que únicamente regresa la búsqueda introducida
                        GameObject salon = Instantiate(ObjSalon, new Vector3(150, 350,0), Quaternion.identity, ObjLista.transform); // Gamobjecto de salon se inicia con un objeto salon, un vector, una identidad y un objeto ObjLista.transform
                        
                        GameObject ImagenSalon = salon.transform.GetChild(0).gameObject; // Gameobject que guardara la imagen del salón
                        GameObject nombreSalonPanel = ImagenSalon.transform.GetChild(0).gameObject; // Gameobject que almacenara el panel nombre del salón

                        GameObject nombreSalon = salon.transform.GetChild(1).gameObject; // Gameobject que almacena el nombre de salón
                        GameObject estadoSalon = salon.transform.GetChild(2).gameObject; // Gameobject que almacena el estado del salón
                        GameObject ubicacionSalon = salon.transform.GetChild(3).gameObject; // Gameobject que almacena la ubicación del salón
                        
                        // Faltan componentes para cada salon                   
                        TMP_Text nsp = nombreSalonPanel.GetComponent<TMP_Text>(); // Se inicializa nsp para que almacene un panel de nombre de salon, es decir, la imagen
                        nsp.text = listaRecibidaSalones.dataSalon[i].aula_clave;  // Se almacena en nsp.text el nombre del panel del salón
                        
                        TMP_Text ns = nombreSalon.GetComponent<TMP_Text>(); // Se inicializa en ns para que almacene el nombre del salón
                        ns.text = listaRecibidaSalones.dataSalon[i].aula_nombre;  // Se almacena en ns.text el nombre del salón
                        
                        TMP_Text es = estadoSalon.GetComponent<TMP_Text>(); // Se inicializa es para que almacene el cambio de estado de salón
                        es.text = listaRecibidaSalones.dataSalon[i].activo ? "Estado: Activo" : "Estado: Inactivo";
                        // es.text = "Estado: " + listaRecibidaSalones.dataSalon[i].activo; // Se le coloca un texto de "Estado Cambiado"

                        TMP_Text us = ubicacionSalon.GetComponent<TMP_Text>(); // Se inicializa us para que almacene la ubicación de salón
                        string ubSalon = listaRecibidaSalones.dataSalon[i].edificio;
                        ubSalon = char.ToUpper(ubSalon[0]) + ubSalon.Substring(1).ToLower(); // Convertir la primera letra a mayúscula
                        us.text = "Edificio: " + ubSalon; // Se le coloca el texto de "Ubicación Cambiada"
                        
                        salon.transform.SetParent(ObjLista.transform); // Indica que el transform del objeto "salon" adquirira las propiedades transform de un objeto nuevo y se volvera hijo de objLista
                        
                        // Id del Salon dentro del objeto salon
                        salonObjeto scriptSalonObjeto = salon.GetComponent<salonObjeto>(); // Se inicializa scriptSalonObjeto para que almacene un id del salón
                        scriptSalonObjeto.idSalon = i+1; // cambiar por el valor real de ID
                        scriptSalonObjeto.cambioPantallas = cambioPantallas; // Cambia la pantalla
                    }
                }   
                Cargando.SetActive(false);                       
                
            }else{ // Si no, ocurrió un error
                Debug.LogWarning("Error en la peticion"); // Mensaje de de error que dice "Error en la petición"
                Error.SetActive(true); // Error se activa
                Recargar.SetActive(true); // Recargar se activa
                Cargando.SetActive(false);  
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
