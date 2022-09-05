using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

using System.Text.Json; 
using System.Text.Json.Serialization;
public class panelProfesor : MonoBehaviour
{
    public GameObject panelPrimeraPantalla;
    public GameObject panelSegundaPantalla;
    public GameObject panelBusqueda;

    //Datos del Profesor
    public GameObject nombreProfesor;
    public GameObject materiaProfesor;
    public GameObject horarioProfesor;
    public GameObject grupoProfesor;
    public GameObject edificioProfesor;
    public GameObject salonProfesor;



    public int idProfesor;

    void Start()
    {
        Debug.Log("Ejecucion cambiar pantalla 1");
        StartCoroutine(CorrutinaObtenerDatos("1"));
    }
    
    public void cambiarPrimerPantalla()
    {
        panelPrimeraPantalla.SetActive(true);
        panelSegundaPantalla.SetActive(false);
        panelBusqueda.SetActive(false);
    }
    public void cambiarSegundaPantalla()
    {
        panelPrimeraPantalla.SetActive(false);
        panelSegundaPantalla.SetActive(true);
        panelBusqueda.SetActive(false);
    }
    public void cambiarPanelBusqueda()
    {
        panelPrimeraPantalla.SetActive(false);
        panelSegundaPantalla.SetActive(false);
        panelBusqueda.SetActive(true);
    }



    [System.Serializable]
    public struct Profesor 
    {
        public string name;
        public string id;
        public string status;
        public string species;
        public string gender;
    }

    public Profesor infoProfesor;

    public IEnumerator CorrutinaObtenerDatos(string busqueda)
    {   
       string url;
       url = "rickandmortyapi.com/api/character/" + busqueda;
        
        UnityWebRequest Peticion = UnityWebRequest.Get(url); //Realizar petición
        yield return Peticion.SendWebRequest();
        
        if(!Peticion.isNetworkError && !Peticion.isHttpError){   //probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
            infoProfesor = JsonUtility.FromJson<Profesor>(Peticion.downloadHandler.text);
            Debug.Log(Peticion.downloadHandler.text);
            //Debug.Log(infoProfesor.results.Length);
    
            // TMP_Text  np = nombreProfesor.GetComponent<TMP_Text>();
            // np.text = informacionProfesor.results[i].name;
            // profe.transform.parent = ObjLista.transform;             
            
            TMP_Text  nombre = nombreProfesor.GetComponent<TMP_Text>();
            nombre.text = infoProfesor.name; 
            

            TMP_Text materia = materiaProfesor.GetComponent<TMP_Text>();
            materia.text = infoProfesor.status; 

            TMP_Text horario = horarioProfesor.GetComponent<TMP_Text>();
            horario.text = infoProfesor.species; 

            TMP_Text grupo = grupoProfesor.GetComponent<TMP_Text>();
            grupo.text = infoProfesor.gender; 

            TMP_Text edificio  = edificioProfesor.GetComponent<TMP_Text>();
            edificio.text = infoProfesor.species; 

            TMP_Text salon = salonProfesor.GetComponent<TMP_Text>();
            salon.text = infoProfesor.id; 

            
            //Debug.Log(infoProfesor.name);
            // public string name;
            // public int id;
            // public string status;
            // public string species;
            // public string gender;    
                                
        }else{
            Debug.LogWarning("Error en la peticion");
            //Recargar.SetActive(true);
        }   
                
    }
}
