using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class MostrarOcultarNombres : MonoBehaviour
{
    /* Objectos del Lienzo 3D */
    public Transform arCamera;
    public Transform transformAula;
    public Transform transformBiblioteca;
    public Transform transformCafeteria;
    public Transform transformCancha;
    public Transform transformColiseo;
    public Transform transformCubiculo;
    public Transform transformInnovacion;
    public Transform transformLaboratorio;
    public PlayableDirector timeline;
    public GameObject canvasAula;
    public GameObject canvasBiblioteca;
    public GameObject canvasCafeteria;
    public GameObject canvasCancha;
    public GameObject canvasColiseo;
    public GameObject canvasCubiculo;
    public GameObject canvasInnovacion;
    public GameObject canvasLaboratorio;
    public Animator animadorAula;
    public Animator animadorBiblioteca;
    public Animator animadorCafeteria;
    public Animator animadorCancha;
    public Animator animadorColiseo;
    public Animator animadorCubiculo;
    public Animator animadorInnovacion;
    public Animator animadorLaboratorio;
    bool activado;

    void Start()
    {
        /* Al iniciar la ejecuci�n se ocultan todas los paneles de nombres */
        canvasAula.SetActive(false);
        canvasBiblioteca.SetActive(false);
        canvasCafeteria.SetActive(false);
        canvasCancha.SetActive(false);
        canvasColiseo.SetActive(false);
        canvasCubiculo.SetActive(false);
        canvasInnovacion.SetActive(false);
        canvasLaboratorio.SetActive(false);
        activado = true;
    }

    public void ReproducirCroquis()
    {
        /* Se reproduce la animaci�n de apertura en los paneles de nombres */
        timeline.Play();
    }

    public void mostrar_ocultarNombres()
    {
        /* Corutina para esperar unos segundos y no desaparezca el panel antes de poder volver a activar el bot�n */
        StartCoroutine(nombresSegundos());
    }

    /* Funci�n que permite esperar unos segundos */
    IEnumerator nombresSegundos()
    {
        /* Se comprueba que se haya activado el bot�n, se muestran los paneles */
        if (activado)
        {
            canvasAula.SetActive(true);
            canvasBiblioteca.SetActive(true);
            canvasCafeteria.SetActive(true);
            canvasCancha.SetActive(true);
            canvasColiseo.SetActive(true);
            canvasCubiculo.SetActive(true);
            canvasInnovacion.SetActive(true);
            canvasLaboratorio.SetActive(true);
            activado = false;
        }
        /* De otra forma se desactivo el bot�n, se dejan de mostrar los paneles */
        else
        {
            animadorAula.SetTrigger("TriggerAula");
            animadorBiblioteca.SetTrigger("TriggerBiblioteca");
            animadorCafeteria.SetTrigger("TriggerCafeteria");
            animadorCancha.SetTrigger("TriggerCancha");
            animadorColiseo.SetTrigger("TriggerColiseo");
            animadorCubiculo.SetTrigger("TriggerCubiculo");
            animadorLaboratorio.SetTrigger("TriggerLaboratorio");
            animadorInnovacion.SetTrigger("TriggerInnovacion");
            yield return new WaitForSeconds(2); //Esperar 2 Segundo
            canvasAula.SetActive(false);
            canvasBiblioteca.SetActive(false);
            canvasCafeteria.SetActive(false);
            canvasCancha.SetActive(false);
            canvasColiseo.SetActive(false);
            canvasCubiculo.SetActive(false);
            canvasInnovacion.SetActive(false);
            canvasLaboratorio.SetActive(false);
            activado = true;
        }
    }

    void Update()
    {
        transformAula.transform.LookAt(arCamera);
        transformBiblioteca.transform.LookAt(arCamera);
        transformCafeteria.transform.LookAt(arCamera);
        transformCancha.transform.LookAt(arCamera);
        transformColiseo.transform.LookAt(arCamera);
        transformCubiculo.transform.LookAt(arCamera);
        transformInnovacion.transform.LookAt(arCamera);
        transformLaboratorio.transform.LookAt(arCamera);

        transformAula.transform.rotation *= Quaternion.Euler(0, 180, 0);
        transformBiblioteca.transform.rotation *= Quaternion.Euler(0, 180, 0);
        transformCafeteria.transform.rotation *= Quaternion.Euler(0, 180, 0);
        transformCancha.transform.rotation *= Quaternion.Euler(0, 180, 0);
        transformColiseo.transform.rotation *= Quaternion.Euler(0, 180, 0);
        transformCubiculo.transform.rotation *= Quaternion.Euler(0, 180, 0);
        transformInnovacion.transform.rotation *= Quaternion.Euler(0, 180, 0);
        transformLaboratorio.transform.rotation *= Quaternion.Euler(0, 180, 0);
    }
}
