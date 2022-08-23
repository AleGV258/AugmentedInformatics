using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPantallas : MonoBehaviour
{
    public GameObject pantallaUno;
    public GameObject pantallaDos;
    bool activado;

    void Start()
    {
        pantallaUno.SetActive(true);
        pantallaDos.SetActive(false);
        activado = true;
    }

    public void cambiarPantalla()
    {
        if(activado)
        {
            pantallaUno.SetActive(false);
            pantallaDos.SetActive(true);
            activado = false;
        }
        else
        {
            pantallaUno.SetActive(true);
            pantallaDos.SetActive(false);
            activado = true;
        }
    }

    void Update()
    {
        
    }
}
