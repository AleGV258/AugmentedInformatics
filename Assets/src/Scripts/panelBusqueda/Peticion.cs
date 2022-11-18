using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class Peticion : MonoBehaviour
{
    [System.Serializable]
    public struct ListaProfesores 
    {
        [System.Serializable]
        public struct resultado{
            public string name;
            public string url;  
        }
        public string count;
        public string next;
        public string previous;
        public resultado[] results;
    }
    [System.Serializable]
    public struct ListaSalones 
    {
        [System.Serializable]
        public struct resultado{
            public string name;
            public string url;  
        }
        public string count;
        public string next;
        public string previous;
        public resultado[] results;
    }

    public ListaProfesores listaRecibidaProfesores; //Lista donde se almacenan los profesores que se reciben
    // public Button BtonClick;
    public TMP_InputField EntradaBuscador;
    public GameObject ObjProfesor;
    public GameObject ObjLista;
    public GameObject Selector;

    public GameObject ObjSalon;
    public ListaSalones listaRecibidaSalones; //Lista donde se almacenan los profesores que se reciben

    public GameObject ObjInputPlaceholder;
    public GameObject ObjTitulo;
    public GameObject Recargar;

    public GameObject panelProfesor;
    public GameObject panelSalon;

    void Start () {
		// Button btn = BtonClick.GetComponent<Button>();
		// BtonClick.onClick.AddListener(ObtenerDatos);
        StartCoroutine(CorrutinaObtenerDatos("")); //Obtener todos los profesores
	}    

    public void ObtenerDatos()
    {
        StartCoroutine(CorrutinaObtenerDatos(EntradaBuscador.text)); // Obtener profesor busqueda
    }
    
    private IEnumerator CorrutinaObtenerDatos(string busqueda)
    {
        Recargar.SetActive(false);

        for (int i = ObjLista.transform.childCount-1; i >= 0; i--) {
            DestroyImmediate(ObjLista.transform.GetChild(i).gameObject);
        }
        int opcionSelector = Selector.GetComponent<TMP_Dropdown>().value;
        
        string url; 
        
        if(opcionSelector == 0){ // Profesores
            TMP_Text OIP = ObjInputPlaceholder.GetComponent<TMP_Text>();
            OIP.text = "Buscar un profesor ... ";
            
            TMP_Text titulo = ObjTitulo.GetComponent<TMP_Text>();
            titulo.text = "Profesores ";
            
            if(busqueda == ""){
                url = "https://pokeapi.co/api/v2/pokemon?limit=" + "30"; //Todos los profesores
            }else{
                url = "https://pokeapi.co/api/v2/pokemon?limit=" + busqueda; //Busqueda filtrada del profesor
            }
            
            UnityWebRequest Peticion = UnityWebRequest.Get(url); //Realizar petición
            yield return Peticion.SendWebRequest();
            
            if(!Peticion.isNetworkError && !Peticion.isHttpError){ //probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
                listaRecibidaProfesores = JsonUtility.FromJson<ListaProfesores>(Peticion.downloadHandler.text);
                // Debug.Log(JsonUtility.ToJson(listaRecibidaProfesores));
                // Debug.Log(listaRecibidaProfesores.results.Length);
                
                for(int i=0; i<listaRecibidaProfesores.results.Length; i++){
                    //Debug.Log(listaRecibidaProfesores.results[i].name);
                    GameObject profe = Instantiate(ObjProfesor, new Vector3(150, 350,0), Quaternion.identity, ObjLista.transform);
                    
                    GameObject imagenProfesor = profe.transform.GetChild(0).gameObject; //Imagen profesor
                    GameObject nombreProfesor = profe.transform.GetChild(1).gameObject; //Nombre profesor
                    GameObject especializacionProfesor = profe.transform.GetChild(2).gameObject; //Especializacion profesor
                    GameObject cubiculoProfesor = profe.transform.GetChild(3).gameObject; //Especializacion profesor
                    //Faltan componentes para cada profesor

                    StartCoroutine(cargarImagenProfesor("https://thumbs.dreamstime.com/b/icono-del-usuario-106603539.jpg", imagenProfesor));

                    TMP_Text np = nombreProfesor.GetComponent<TMP_Text>();
                    np.text = listaRecibidaProfesores.results[i].name;
                    profe.transform.parent = ObjLista.transform; 
                    
                    TMP_Text ep = especializacionProfesor.GetComponent<TMP_Text>();
                    ep.text = "Especialización del profesor";

                    TMP_Text cp = cubiculoProfesor.GetComponent<TMP_Text>();
                    cp.text = "C09";

                    //Id del profesor dentro del objeto profe
                    profeObjeto profesorID = profe.GetComponent<profeObjeto>();
                    profesorID.idProfesor = i; //cambiar por el valor real de ID
                    profesorID.panelProfesores = panelProfesor;
                }                        
            }else{
                Debug.LogWarning("Error en la peticion");
                Recargar.SetActive(true);
            }   
        }else{ // Salones
            TMP_Text OIP = ObjInputPlaceholder.GetComponent<TMP_Text>();
            OIP.text = "Buscar un salón ... ";

            TMP_Text titulo = ObjTitulo.GetComponent<TMP_Text>();
            titulo.text = "Salones ";

            if(busqueda == ""){
                url = "https://pokeapi.co/api/v2/pokemon?limit=" + "30"; //Todos los salones
            }else{
                url = "https://pokeapi.co/api/v2/pokemon?limit=" + busqueda; //Busqueda filtrada del salon
            }
            
            UnityWebRequest Peticion = UnityWebRequest.Get(url); //Realizar petición
            yield return Peticion.SendWebRequest();
            
            if(!Peticion.isNetworkError && !Peticion.isHttpError){ //probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
                listaRecibidaSalones = JsonUtility.FromJson<ListaSalones>(Peticion.downloadHandler.text);
                // Debug.Log(JsonUtility.ToJson(listaRecibidaSalones));
                // Debug.Log(listaRecibidaSalones.results.Length);                
                
                for(int i= 0; i< listaRecibidaSalones.results.Length; i++){
                    //Debug.Log(listaRecibidaSalones.results[i].name);
                    GameObject salon = Instantiate(ObjSalon, new Vector3(150, 350,0), Quaternion.identity, ObjLista.transform);
                    
                    GameObject ImagenSalon = salon.transform.GetChild(0).gameObject;
                    GameObject nombreSalonPanel = ImagenSalon.transform.GetChild(0).gameObject;

                    GameObject nombreSalon = salon.transform.GetChild(1).gameObject; 
                    GameObject estadoSalon = salon.transform.GetChild(2).gameObject; 
                    GameObject ubicacionSalon = salon.transform.GetChild(3).gameObject; 
                    //Faltan componentes para cada salon                   

                    TMP_Text nsp = nombreSalonPanel.GetComponent<TMP_Text>();
                    nsp.text = listaRecibidaSalones.results[i].name; 
                    
                    TMP_Text ns = nombreSalon.GetComponent<TMP_Text>();
                    ns.text = listaRecibidaSalones.results[i].name; 
                    
                    TMP_Text es = estadoSalon.GetComponent<TMP_Text>();
                    es.text = "Estado Cambiado";

                    TMP_Text us = ubicacionSalon.GetComponent<TMP_Text>();
                    us.text = "Ubicacion Cambiada";
                    
                    salon.transform.parent = ObjLista.transform;
                    
                    //Id del Salon dentro del objeto salon
                    salonObjeto scriptSalonObjeto = salon.GetComponent<salonObjeto>();
                    scriptSalonObjeto.idSalon = i; //cambiar por el valor real de ID
                    scriptSalonObjeto.panelSalones = panelSalon;
                }                        
            }else{
                Debug.LogWarning("Error en la peticion");
                Recargar.SetActive(true);
            }   
        }
        
    }

    public IEnumerator cargarImagenProfesor(string MediaUrl, GameObject imagenProfesor)
    {   
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();

        if(request.isNetworkError || request.isHttpError){
            Debug.Log(request.error);
        }else{
            Texture myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            RawImage imagenRequestProfesor = imagenProfesor.GetComponent<RawImage>();
            imagenRequestProfesor.texture = myTexture;
        }            
    }
}
