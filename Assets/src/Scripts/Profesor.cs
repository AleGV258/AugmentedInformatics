using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class profesor : MonoBehaviour
{
    public int idProfesor;
    // Start is called before the first frame update
    void Start()
    {
        
    } 
    public GameObject mapa;
    public void cambiarDePanel()
    {
        mapa.SetActive(true);
        // GameObject textoMapa = mapa.transform.GetChild(0).gameObject;
        // TMP_Text  tm = textoMapa.GetComponent<TMP_Text>();
        // tm.text = "Cambia";
        Mapa profesorID = mapa.GetComponent <Mapa> ();
        profesorID.idProfe = idProfesor;
    }
}
