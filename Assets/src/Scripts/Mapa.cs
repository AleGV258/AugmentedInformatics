using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    public int idProfe;
    public GameObject PanelBusqueda;
    public GameObject PanelMapa;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("El id de profesor recibido es :" + idProfe);
    }
    public void regresarPanel(){
        Debug.Log("Regresar a panel de busqueda");
        PanelBusqueda.SetActive(true);
        PanelMapa.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
