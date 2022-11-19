using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

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

    public GameObject panelCargando;

    // Datos del Salón
    public GameObject nombreProfesor;
    public GameObject materiaProfesor;
    public GameObject horarioProfesor;
    public GameObject grupoProfesor;
    public GameObject edificioProfesor;
    public GameObject salonProfesor;
    public GameObject imagenProfesor;
    // Datos del Salón en el UI
    public GameObject nombreProfesorUI;
    public GameObject materiaProfesorUI;
    public GameObject horarioProfesorUI;
    public GameObject grupoProfesorUI;
    public GameObject edificioProfesorUI;
    public GameObject salonProfesorUI;
    public GameObject imagenProfesorUI;

    public int idSalon = 1;
    public int idProfesorEnSalon = 1;

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
        interfazAR.SetActive(false);
        realidadAumentada.SetActive(true);

        panelSalon scriptPanelSalon = panel1Salon.GetComponent<panelSalon>();
        idSalon = scriptPanelSalon.idSalon; // Se envia del en el que se encuentra 
        
        StartCoroutine(CorrutinaObtenerDatos());
    }

    public void cambiarPrimerPantallaUI()
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
        idSalon = scriptPanelSalon.idSalon; // Se envia del en el que se encuentra 
        
        StartCoroutine(CorrutinaObtenerDatos());
    }

    [System.Serializable]
    public struct Profesor 
    {
        public string name;
        public string id;
        public string status;
        public string species;
        public string gender;
        public string image;
    }
    [System.Serializable]
    public struct Salon 
    {
        public string name;
        public string id;
        public string status;
    }

    public Profesor infoProfesor;
    public Salon infoSalon;

    public IEnumerator CorrutinaObtenerDatos()
    {   
        panelCargando.SetActive(true);
        //Obtener informacion del profesor y del salon

        //Obtener informacion del Salon
        string url;
        url = "rickandmortyapi.com/api/character/" + idSalon.ToString();;
        UnityWebRequest Peticion = UnityWebRequest.Get(url); // Realizar petición
        yield return Peticion.SendWebRequest();
        
        if(!Peticion.isNetworkError && !Peticion.isHttpError){ //Probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
            infoSalon = JsonUtility.FromJson<Salon>(Peticion.downloadHandler.text);
            //Debug.Log(Peticion.downloadHandler.text);          
            
            // Salón
            TMP_Text edificio = edificioProfesor.GetComponent<TMP_Text>();
            edificio.text = infoSalon.status; 
            TMP_Text salon = salonProfesor.GetComponent<TMP_Text>();
            salon.text = infoSalon.id;

            // Salón UI
            TMP_Text edificioUI = edificioProfesorUI.GetComponent<TMP_Text>();
            edificioUI.text = infoSalon.status; 
            TMP_Text salonUI = salonProfesorUI.GetComponent<TMP_Text>();
            salonUI.text =  infoSalon.id;    
            
            // Obtener informacion del profesor que se encuentra en el salon
            idProfesorEnSalon = idSalon; //TEMPORALMENTE ES EL MISMO ID, CAMBIARA CUANDO TENGAMOS API AL ID REAL
            
            
            StartCoroutine(ObtenerDatosProfesor());
            panelCargando.SetActive(false);

        }else{
            Debug.LogWarning("Error en la peticion");
            panelCargando.SetActive(false);
            //Recargar.SetActive(true);
        }             
    }
    public void SiguienteProfesor(){
        idProfesorEnSalon = idProfesorEnSalon + 1; //TEMPORALMENTE SE SUMA 1, DESPUES API TENDRA EL ID DEL SIG PROFESOR
        StartCoroutine(ObtenerDatosProfesor());
    }
    public void AnteriorProfesor(){
        idProfesorEnSalon = idProfesorEnSalon - 1; //TEMPORALMENTE SE SUMA 1, DESPUES API TENDRA EL ID DEL SIG PROFESOR
        StartCoroutine(ObtenerDatosProfesor());
    }
    public IEnumerator ObtenerDatosProfesor()
    {   
        panelCargando.SetActive(true);
        string url;
        url = "rickandmortyapi.com/api/character/" + idProfesorEnSalon.ToString();
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
            TMP_Text grupo = grupoProfesor.GetComponent<TMP_Text>();
            grupo.text = infoProfesor.gender; 
            TMP_Text horario = horarioProfesor.GetComponent<TMP_Text>();
            horario.text = infoProfesor.name; 
            StartCoroutine(cargarImagenProfesor(infoProfesor.image, imagenProfesor));
            
            // Salón UI
            TMP_Text nombreUI = nombreProfesorUI.GetComponent<TMP_Text>();
            nombreUI.text = infoProfesor.name;            
            TMP_Text materiaUI = materiaProfesorUI.GetComponent<TMP_Text>();
            materiaUI.text = infoProfesor.status; 
            TMP_Text grupoUI = grupoProfesorUI.GetComponent<TMP_Text>();
            grupoUI.text = infoProfesor.gender;   
            TMP_Text horarioUI = horarioProfesorUI.GetComponent<TMP_Text>();
            horarioUI.text = infoProfesor.name; 
            
            StartCoroutine(cargarImagenProfesor(infoProfesor.image, imagenProfesorUI));
            panelCargando.SetActive(false);
        }else{
            Debug.LogWarning("Error en la peticion");
            panelCargando.SetActive(false);
            //Recargar.SetActive(true);
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
