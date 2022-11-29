using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetId : MonoBehaviour
{
    public int idTargetSalon=0;
    public GameObject Target;
    public GameObject cambioPantallas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pasarId()
    {
        MenuPrincipal menu = cambioPantallas.GetComponent<MenuPrincipal>();
        menu.idSalon = idTargetSalon;
        menu.targetRecibido = Target;
        menu.cambiarPadrePanelesTarget();
        menu.cambiarPrimerPantalla();
        // panelSalon salon = instanciaPanelSalon.GetComponent<panelSalon>();
        // salon.idSalon = idTargetSalon;
        // StartCoroutine(salon.CorrutinaObtenerDatos());
    }
}
