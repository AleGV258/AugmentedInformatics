using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class ScriptPantallas : MonoBehaviour
{
    public Transform arCamera;
    public Transform transformCanvasPantallas;
    public PlayableDirector timeline;
    public GameObject pantallaUno;
    public GameObject pantallaDos;
    bool activado;
    //public int prueba = 10;

    void Start()
    {
        pantallaUno.SetActive(true);
        pantallaDos.SetActive(false);
        activado = true;
    }

    public void reproducirPantalla()
    {
        timeline.Play();
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
        transformCanvasPantallas.transform.LookAt(arCamera);
        transformCanvasPantallas.transform.rotation *= Quaternion.Euler(0, 180, 0);
    }
}
