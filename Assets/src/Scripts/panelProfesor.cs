using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelProfesor : MonoBehaviour
{
    public GameObject panelPrimeraPantalla;
    public GameObject panelSegundaPantalla;
    public GameObject panelBusqueda;

    public int idProfesor;

    void Start()
    {
        Debug.Log("Ejecucion cambiar pantalla 1");
    }

    void Update()
    {
        
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
    }

    // private IEnumerator CorrutinaObtenerDatos(string busqueda)
    // {   
    //    string url = "rickandmortyapi.com/api/character/1";
        
    //     UnityWebRequest Peticion = UnityWebRequest.Get(url); //Realizar petición
    //     yield return Peticion.SendWebRequest();
        
    //     if(!Peticion.isNetworkError && !Peticion.isHttpError){   //probar UnityWebRequest.result == UnityWebRequest.Result.ProtocolError        
    //         informacionProfesor = JsonUtility.FromJson<ListaProfesores>(Peticion.downloadHandler.text);
    //         Debug.Log(JsonUtility.ToJson(informacionProfesor));
    //         Debug.Log(informacionProfesor.results.Length);
    
    //             // TMP_Text  np = nombreProfesor.GetComponent<TMP_Text>();
    //             // np.text = informacionProfesor.results[i].name;
    //             // profe.transform.parent = ObjLista.transform; 
    //             Debug.Log(
                                
    //     }else{
    //         Debug.LogWarning("Error en la peticion");
    //         Recargar.SetActive(true);
    //     }   
                
    // }
}
