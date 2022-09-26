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
        //Debug.Log("Ejecucion cambiar pantalla 1");
        Debug.Log("Inicia corrutina en panelProvesor - start");
        StartCoroutine(CorrutinaObtenerDatos());
    }
    
    public void cambiarPrimerPantalla()
    {
        panelPrimeraPantalla.SetActive(true);
        panelSegundaPantalla.SetActive(false);
        panelBusqueda.SetActive(false);
        StartCoroutine(CorrutinaObtenerDatos());
        Debug.Log("Inicia corrutina en panelProvesor - cambiarPrimerPantalla");
    }
    // public void cambiarSegundaPantalla()
    // {
    //     panelPrimeraPantalla.SetActive(false);
    //     panelSegundaPantalla.SetActive(true);
    //     panelBusqueda.SetActive(false);
        
    //     panelProfesor scriptPanelProfesor = panelSegundaPantalla.GetComponent <panelProfesor> ();
    //     scriptPanelProfesor.idProfesor = idProfesor;
    //     scriptPanelProfesor.cambiarSegundaPantalla();
    // }
    // public void cambiarPanelBusqueda()
    // {
    //     panelPrimeraPantalla.SetActive(false);
    //     panelSegundaPantalla.SetActive(false);
    //     panelBusqueda.SetActive(true);
    //     panel2Profesor panel1ProfesorScript = panelSegundaPantalla.GetComponent <panel2Profesor> ();
    //     panel1ProfesorScript.idProfesor = idProfesor;
    // }

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

    public IEnumerator CorrutinaObtenerDatos()
    {   
       string url;
       url = "rickandmortyapi.com/api/character/" + idProfesor.ToString();;
        
        UnityWebRequest Peticion = UnityWebRequest.Get(url); //Realizar petición
        yield return Peticion.SendWebRequest();
        
        if(!Peticion.isNetworkError && !Peticion.isHttpError){   //probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
            infoProfesor = JsonUtility.FromJson<Profesor>(Peticion.downloadHandler.text);
            Debug.Log(Peticion.downloadHandler.text);          
            
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
                                
        }else{
            Debug.LogWarning("Error en la peticion");
            //Recargar.SetActive(true);
        }             
    }
}
