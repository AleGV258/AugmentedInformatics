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
    public GameObject pantallaUnoUI;
    public GameObject pantallaDosUI;

    void Start()
    {
        pantallaUno.SetActive(true);
        pantallaDos.SetActive(false);
    }

    public void reproducirPantalla()
    {
        timeline.Play();
    }

    public void pantallaSalon()
    {
        pantallaUno.SetActive(true);
        pantallaDos.SetActive(false);
    }

    public void pantallaProfesor()
    {
        pantallaUno.SetActive(false);
        pantallaDos.SetActive(true);
    }

    public void pantallaSalonUI()
    {
        pantallaUnoUI.SetActive(true);
        pantallaDosUI.SetActive(false);
    }

    public void pantallaProfesorUI()
    {
        pantallaUnoUI.SetActive(false);
        pantallaDosUI.SetActive(true);
    }

    void Update()
    {
        //transformCanvasPantallas.transform.LookAt(arCamera);
        //transformCanvasPantallas.transform.rotation *= Quaternion.Euler(0, 180, 0);
    }    
}
