using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarProfe : MonoBehaviour
{
    public GameObject PanelProfe;
    public GameObject GameObjectTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void instanciarPanelProfesor()
    {
        GameObject PanelProfesorInstanciado = Instantiate(PanelProfe, new Vector3(0, 0, 0), Quaternion.identity, GameObjectTarget.transform);
        PanelProfesorInstanciado.transform.parent = GameObjectTarget.transform; 
        // = GameObjectTarget.transform.position
        PanelProfesorInstanciado.SetActive(true);
    }

    // Método para eliminar el objeto creado
    // Hacer que el objeto este bien colocado (tamaños y coordenadas dinámicas)
    // Probar con diferentes targets
}
