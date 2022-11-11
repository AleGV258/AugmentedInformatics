using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;


public class panelProfesor : MonoBehaviour
{
    public GameObject panel1Salon;
    public GameObject panel2Profesor;
    public GameObject panelBusqueda;
    public GameObject arCamera;
    public GameObject realidadAumentada;

    //Datos del Profesor
    //public GameObject nombreProfesor;
    public GameObject especializacionProfesor;
    public GameObject areaConocimiento;
    public GameObject curruculum;
    public GameObject cubiculo;    

    public int idProfesor;

    void Start()
    {
        // Debug.Log("Ejecucion cambiar pantalla 1");
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
        panelBusqueda.SetActive(false);
        arCamera.SetActive(true);
        realidadAumentada.SetActive(true);

        //---------------------------------------
        panelProfesor scriptPanelProfesor = panel1Salon.GetComponent <panelProfesor> ();
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
    }

    public InformacionProfesor infoExtraProfesor;

    public IEnumerator CorrutinaObtenerDatos()
    {   
       string url;
       url = "rickandmortyapi.com/api/character/" + idProfesor.ToString();;
        
        UnityWebRequest Peticion = UnityWebRequest.Get(url); //Realizar petición
        yield return Peticion.SendWebRequest();
        
        if(!Peticion.isNetworkError && !Peticion.isHttpError){ //probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
            infoExtraProfesor = JsonUtility.FromJson<InformacionProfesor>(Peticion.downloadHandler.text);
            Debug.Log(Peticion.downloadHandler.text);          
            
            // TMP_Text  nombre = nombreProfesor.GetComponent<TMP_Text>();
            // nombre.text = infoExtraProfesor.name;            

            TMP_Text especializacion = especializacionProfesor.GetComponent<TMP_Text>();
            especializacion.text = infoExtraProfesor.name + " / " + infoExtraProfesor.status; 

            TMP_Text area = areaConocimiento.GetComponent<TMP_Text>();
            area.text = infoExtraProfesor.species; 

            TMP_Text curruculumTexto = curruculum.GetComponent<TMP_Text>();
            curruculumTexto.text = infoExtraProfesor.gender; 

            TMP_Text edificio  = cubiculo.GetComponent<TMP_Text>();
            edificio.text = infoExtraProfesor.species;                         
        }else{
            Debug.LogWarning("Error en la peticion");
            //Recargar.SetActive(true);
        }             
    }
}
