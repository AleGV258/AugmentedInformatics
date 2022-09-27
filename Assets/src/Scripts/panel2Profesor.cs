using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

using System.Text.Json; 
using System.Text.Json.Serialization;

public class panel2Profesor : MonoBehaviour
{
    public GameObject panelPrimeraPantalla;
    public GameObject panelSegundaPantalla;
    public GameObject panelBusqueda;

    //Datos del Profesor
    //public GameObject nombreProfesor;
    public GameObject especializacionProfesor;
    public GameObject areaConocimiento;
    public GameObject curruculum;
    public GameObject cubiculo;    


    public int idProfesor;

    void Start()
    {
        Debug.Log("Ejecucion cambiar pantalla 1");
        StartCoroutine(CorrutinaObtenerDatos());
    }
    
    // public void cambiarPrimerPantalla()
    // {
    //     panelPrimeraPantalla.SetActive(true);
    //     panelSegundaPantalla.SetActive(false);
    //     panelBusqueda.SetActive(false);
    //     StartCoroutine(CorrutinaObtenerDatos());
    // }
    public void cambiarSegundaPantalla()
    {
        panelPrimeraPantalla.SetActive(false);
        panelSegundaPantalla.SetActive(true);
        panelBusqueda.SetActive(false);
        
        
        panelProfesor scriptPanelProfesor = panelPrimeraPantalla.GetComponent <panelProfesor> ();
        idProfesor = scriptPanelProfesor.idProfesor;
        
        //StartCoroutine(CorrutinaObtenerDatos());
    }
    // public void cambiarPanelBusqueda()
    // {
    //     panelPrimeraPantalla.SetActive(false);
    //     panelSegundaPantalla.SetActive(false);
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
        
        if(!Peticion.isNetworkError && !Peticion.isHttpError){   //probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
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
