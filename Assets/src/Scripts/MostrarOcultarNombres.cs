using System.Collections;
using UnityEngine;

public class MostrarOcultarNombres : MonoBehaviour
{
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
        canvasAula.SetActive(false);
        canvasBiblioteca.SetActive(false);
        canvasCafeteria.SetActive(false);
        canvasCancha.SetActive(false);
        canvasColiseo.SetActive(false);
        canvasCubiculo.SetActive(false);
        canvasInnovacion.SetActive(false);
        canvasLaboratorio.SetActive(false);
        activado = false;
    }

    public void mostrar_ocultarNombres()
    {
        StartCoroutine(nombresSegundos());
    }

    IEnumerator nombresSegundos()
    {
        if (activado == false)
        {
            canvasAula.SetActive(true);
            canvasBiblioteca.SetActive(true);
            canvasCafeteria.SetActive(true);
            canvasCancha.SetActive(true);
            canvasColiseo.SetActive(true);
            canvasCubiculo.SetActive(true);
            canvasInnovacion.SetActive(true);
            canvasLaboratorio.SetActive(true);
            activado = true;
        }
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
            yield return new WaitForSeconds(2); //Esperar 1 Segundo
            canvasAula.SetActive(false);
            canvasBiblioteca.SetActive(false);
            canvasCafeteria.SetActive(false);
            canvasCancha.SetActive(false);
            canvasColiseo.SetActive(false);
            canvasCubiculo.SetActive(false);
            canvasInnovacion.SetActive(false);
            canvasLaboratorio.SetActive(false);
            activado = false;
        }
        
        

    }
}
