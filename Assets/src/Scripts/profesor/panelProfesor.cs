using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class panelProfesor : MonoBehaviour
{
    public GameObject panel1Salon;
    public GameObject panel2Profesor;
    public GameObject panel1SalonUI;
    public GameObject panel2ProfesorUI;
    public GameObject panelBusqueda;
    public GameObject arCamera;
    public GameObject interfazAR;
    public GameObject realidadAumentada;

    // Datos del Profesor
    public GameObject especializacionNombreProfesor;
    public GameObject areaConocimiento;
    public GameObject curriculum;
    public GameObject cubiculo;
    public GameObject imagenProfesor;
    // Datos del Profesor en el UI
    public GameObject especializacionNombreProfesorUI;
    public GameObject areaConocimientoUI;
    public GameObject curriculumUI;
    public GameObject cubiculoUI;   
    public GameObject imagenProfesorUI; 

    public int idProfesor = 1;

    void Start()
    {
        // Debug.Log("Ejecucion cambiar pantalla 2");
        // StartCoroutine(CorrutinaObtenerDatos());
    }
    
    // public void cambiarPrimerPantalla()
    // {
    //     panel1Salon.SetActive(true);
    //     panel2Profesor.SetActive(false);
    //     panelBusqueda.SetActive(false);
    //     StartCoroutine(CorrutinaObtenerDatos());
    // }

    public void cambiarSegundaPantalla()
    {
        panel1Salon.SetActive(false);
        panel2Profesor.SetActive(true);
        panel1SalonUI.SetActive(false);
        panel2ProfesorUI.SetActive(true);
        panelBusqueda.SetActive(false);
        arCamera.SetActive(true);
        interfazAR.SetActive(false);
        realidadAumentada.SetActive(true);

        panelProfesor scriptPanelProfesor = panel2Profesor.GetComponent<panelProfesor>();
        idProfesor = scriptPanelProfesor.idProfesor; 

        panelSalon scriptpanelSalon = panel1Salon.GetComponent<panelSalon>();
        scriptpanelSalon.idProfesorEnSalon =idProfesor; 
        
        StartCoroutine(CorrutinaObtenerDatos());
    }

    public void cambiarSegundaPantallaUI()
    {
        panel1Salon.SetActive(false);
        panel2Profesor.SetActive(true);
        panel1SalonUI.SetActive(false);
        panel2ProfesorUI.SetActive(true);
        panelBusqueda.SetActive(false);
        arCamera.SetActive(true);
        interfazAR.SetActive(true);
        realidadAumentada.SetActive(true);

        panelProfesor scriptPanelProfesor = panel2Profesor.GetComponent<panelProfesor>();
        idProfesor = scriptPanelProfesor.idProfesor; 
        
        StartCoroutine(CorrutinaObtenerDatos());
    }

    // public void cambiarPanelBusqueda()
    // {
    //     panel1Salon.SetActive(false);
    //     panel2Profesor.SetActive(false);
    //     panelBusqueda.SetActive(true);
    // }

    [System.Serializable]
    public struct InformacionProfesor 
    {
        public string name;
        public string id;
        public string status;
        public string species;
        public string gender;
        public string image;
    }

    public InformacionProfesor infoExtraProfesor;

    public IEnumerator CorrutinaObtenerDatos()
    {   
        string url;
        url = "rickandmortyapi.com/api/character/" + idProfesor.ToString();
        UnityWebRequest Peticion = UnityWebRequest.Get(url); // Realizar petición
        yield return Peticion.SendWebRequest();
        
        if(!Peticion.isNetworkError && !Peticion.isHttpError){ //probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
            infoExtraProfesor = JsonUtility.FromJson<InformacionProfesor>(Peticion.downloadHandler.text);
            //Debug.Log(Peticion.downloadHandler.text);          
            
            // Profesor        
            TMP_Text especializacion = especializacionNombreProfesor.GetComponent<TMP_Text>();
            especializacion.text = infoExtraProfesor.name + " / " + infoExtraProfesor.status; 
            TMP_Text area = areaConocimiento.GetComponent<TMP_Text>();
            area.text = infoExtraProfesor.species; 
            TMP_Text curriculumTexto = curriculum.GetComponent<TMP_Text>();
            curriculumTexto.text = infoExtraProfesor.gender; 
            TMP_Text edificio = cubiculo.GetComponent<TMP_Text>();
            edificio.text = infoExtraProfesor.species;
            StartCoroutine(cargarImagenProfesor(infoExtraProfesor.image, imagenProfesor)); 

            // Profesor UI
            TMP_Text especializacionUI = especializacionNombreProfesorUI.GetComponent<TMP_Text>();
            especializacionUI.text = infoExtraProfesor.name + " / " + infoExtraProfesor.status; 
            TMP_Text areaUI = areaConocimientoUI.GetComponent<TMP_Text>();
            areaUI.text = infoExtraProfesor.species; 
            TMP_Text curriculumTextoUI = curriculumUI.GetComponent<TMP_Text>();
            curriculumTextoUI.text = infoExtraProfesor.gender; 
            TMP_Text edificioUI = cubiculoUI.GetComponent<TMP_Text>();
            edificioUI.text = infoExtraProfesor.species;         
            StartCoroutine(cargarImagenProfesor(infoExtraProfesor.image, imagenProfesorUI));         
        }else{
            Debug.LogWarning("Error en la peticion");
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
