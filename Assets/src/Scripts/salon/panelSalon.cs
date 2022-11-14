using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class panelSalon : MonoBehaviour
{
    public GameObject panel1Salon;
    public GameObject panel2Profesor;
    public GameObject panel1SalonUI;
    public GameObject panel2ProfesorUI;
    public GameObject panelBusqueda;
    public GameObject arCamera;
    public GameObject interfazAR;
    public GameObject realidadAumentada;

    // Datos del Salón
    public GameObject nombreProfesor;
    public GameObject materiaProfesor;
    public GameObject horarioProfesor;
    public GameObject grupoProfesor;
    public GameObject edificioProfesor;
    public GameObject salonProfesor;
    // Datos del Salón en el UI
    public GameObject nombreProfesorUI;
    public GameObject materiaProfesorUI;
    public GameObject horarioProfesorUI;
    public GameObject grupoProfesorUI;
    public GameObject edificioProfesorUI;
    public GameObject salonProfesorUI;

    public int idSalon;

    void Start()
    {
        //Debug.Log("Ejecucion cambiar pantalla 1");
        //StartCoroutine(CorrutinaObtenerDatos());
    }
    
    public void cambiarPrimerPantalla()
    {
        panel1Salon.SetActive(true);
        panel2Profesor.SetActive(false);
        panel1SalonUI.SetActive(true);
        panel2ProfesorUI.SetActive(false);
        panelBusqueda.SetActive(false);
        arCamera.SetActive(true);
        interfazAR.SetActive(true);
        realidadAumentada.SetActive(true);

        panelSalon scriptPanelSalon = panel1Salon.GetComponent<panelSalon>();
        idSalon = scriptPanelSalon.idSalon; //Se envia del en el que se encuentra 
        
        StartCoroutine(CorrutinaObtenerDatos());
    }
    // public void cambiarSegundaPantalla()
    // {
    //     panel1Salon.SetActive(false);
    //     panel2Profesor.SetActive(true);
    //     panelBusqueda.SetActive(false);
        
    //     panelProfesor scriptPanelProfesor = panel2Profesor.GetComponent <panelProfesor> ();
    //     scriptPanelProfesor.idSalon = idSalon;
    //     scriptPanelProfesor.cambiarSegundaPantalla();
    // }
    // public void cambiarPanelBusqueda()
    // {
    //     panel1Salon.SetActive(false);
    //     panel2Profesor.SetActive(false);
    //     panelBusqueda.SetActive(true);
    //     panel2Profesor panel1ProfesorScript = panel2Profesor.GetComponent <panel2Profesor> ();
    //     panel1ProfesorScript.idSalon = idSalon;
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
       url = "rickandmortyapi.com/api/character/" + idSalon.ToString();;
        
        UnityWebRequest Peticion = UnityWebRequest.Get(url); //Realizar petición
        yield return Peticion.SendWebRequest();
        
        if(!Peticion.isNetworkError && !Peticion.isHttpError){ //Probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
            infoProfesor = JsonUtility.FromJson<Profesor>(Peticion.downloadHandler.text);
            //Debug.Log(Peticion.downloadHandler.text);          
            
            // Salón
            TMP_Text nombre = nombreProfesor.GetComponent<TMP_Text>();
            nombre.text = infoProfesor.name;            
            TMP_Text materia = materiaProfesor.GetComponent<TMP_Text>();
            materia.text = infoProfesor.status; 
            TMP_Text horario = horarioProfesor.GetComponent<TMP_Text>();
            horario.text = infoProfesor.species; 
            TMP_Text grupo = grupoProfesor.GetComponent<TMP_Text>();
            grupo.text = infoProfesor.gender; 
            TMP_Text edificio = edificioProfesor.GetComponent<TMP_Text>();
            edificio.text = infoProfesor.species; 
            TMP_Text salon = salonProfesor.GetComponent<TMP_Text>();
            salon.text = infoProfesor.id;

            // Salón UI
            TMP_Text nombreUI = nombreProfesorUI.GetComponent<TMP_Text>();
            nombreUI.text = infoProfesor.name;            
            TMP_Text materiaUI = materiaProfesorUI.GetComponent<TMP_Text>();
            materiaUI.text = infoProfesor.status; 
            TMP_Text horarioUI = horarioProfesorUI.GetComponent<TMP_Text>();
            horarioUI.text = infoProfesor.species; 
            TMP_Text grupoUI = grupoProfesorUI.GetComponent<TMP_Text>();
            grupoUI.text = infoProfesor.gender; 
            TMP_Text edificioUI = edificioProfesorUI.GetComponent<TMP_Text>();
            edificioUI.text = infoProfesor.species; 
            TMP_Text salonUI = salonProfesorUI.GetComponent<TMP_Text>();
            salonUI.text = infoProfesor.id;     
        }else{
            Debug.LogWarning("Error en la peticion");
            //Recargar.SetActive(true);
        }             
    }
}
