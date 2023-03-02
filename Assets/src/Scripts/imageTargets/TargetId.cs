using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetId : MonoBehaviour
{
    public int idTargetSalon; // Id del ImageTarget
    public GameObject Target; // GameObject del ImageTarget
    public GameObject cambioPantallas; // GameObject del script cambio pantallas

    // Función para colocar el id del target en el componente y gameobject de menuprincipal, para posteriormente pasar este id a los paneles virtuales y de realidad aumentada
    public void pasarId()
    {
        MenuPrincipal menu = cambioPantallas.GetComponent<MenuPrincipal>(); // Se obtiene el GameObject de MenuPrincipal
        menu.idSalon = idTargetSalon; // Se establece el id del target
        menu.targetRecibido = Target; // Se establece el target
        menu.cambiarPadrePanelesTarget(); // Se cambia su GameObject padre, o el que lo va a contener
        menu.cambiarPantallaRealidadAumentadaSalon(); // Se activa el panel de realidad aumentada en el salón
        // panelSalon salon = instanciaPanelSalon.GetComponent<panelSalon>();
        // salon.idSalon = idTargetSalon;
        // StartCoroutine(salon.CorrutinaObtenerDatos());
    }
}
