using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

using System.Text.Json; 
using System.Text.Json.Serialization;

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

    public ListaProfesores listaRecibidaProfesores;

    public Button BtonClick;
    public TMP_InputField EntradaBuscador;
    public GameObject ObjProfesor;
    public GameObject ObjListaProfesores;

    void Start () {
		Button btn = BtonClick.GetComponent<Button>();
		BtonClick.onClick.AddListener(ObtenerDatos);
        CorrutinaObtenerDatos("1");//Obtener todos los profesores 
	}    
       
    public void ObtenerDatos()
    {
        //Debug.Log(EntradaBuscador.text);
        StartCoroutine(CorrutinaObtenerDatos(EntradaBuscador.text));//Obtener profesor busqueda
    }
    
    //public ListaProfesor lista = new ListaProfesor();
    
    private IEnumerator CorrutinaObtenerDatos(string busqueda)
    {   
        string url = "https://pokeapi.co/api/v2/pokemon?limit=" + busqueda; //Dirección
        //Debug.Log(url);
        UnityWebRequest Peticion = UnityWebRequest.Get(url); //Realizar petición
        yield return Peticion.SendWebRequest();
        if(!Peticion.isNetworkError && !Peticion.isHttpError){            
            listaRecibidaProfesores = JsonUtility.FromJson<ListaProfesores>(Peticion.downloadHandler.text);
            Debug.Log(JsonUtility.ToJson(listaRecibidaProfesores));
            for(int i= 0; i< listaRecibidaProfesores.results.Length; i++){
                //Debug.Log(listaRecibidaProfesores.results[i].name);
                GameObject profe = Instantiate(ObjProfesor, new Vector3(150, 350,0), Quaternion.identity, ObjListaProfesores.transform);
                GameObject child2 = profe.transform.GetChild(0).gameObject;
                TMP_Text  prueba = child2.GetComponent<TMP_Text>();
                prueba.text = listaRecibidaProfesores.results[i].name;
                profe.transform.parent = ObjListaProfesores.transform;
                
            }                        
        }else{
            Debug.LogWarning("Error en la peticion");
        }   
    }

}
