using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using UnityEngine.UI;

public class MostrarOcultarNombres : MonoBehaviour
{
    /* Objectos del Lienzo 3D */
    public Transform arCamera; // GameObject de la cámara del dispositivo
    public Transform transformAula; // Transform del modelo del Aula
    public Transform transformAuditorio; // Transform del modelo del auditorio
    public Transform transformBiblioteca; // Transform del modelo de la Biblioteca
    public Transform transformCafeteria; // Transform del modelo del la Cafeteria
    public Transform transformCancha; // Transform del modelo de la Cancha
    public Transform transformColiseo; // Transform del modelo del Coliceo
    public Transform transformCubiculo; // Transform del modelo Cubiculo
    public Transform transformInnovacion; // Transform del modelo de Innovacion
    public Transform transformLaboratorio; // Transform del modelo de Laboratorio
    public PlayableDirector timeline; // PlayableDirector del Croquis
    public GameObject canvasAula; // Canvas del nombre del modelo Aula
    public GameObject canvasAuditorio; // Canvas del nombre del modelo Auditorio
    public GameObject canvasBiblioteca; // Canvas del nombre del modelo Biblioteca
    public GameObject canvasCafeteria; // Canvas del nombre del modelo Cancha
    public GameObject canvasCancha; // Canvas del nombre del modelo Cancha 
    public GameObject canvasColiseo; // Canvas del nombre del modelo Coliseo
    public GameObject canvasCubiculo; // Canvas del nombre del modelo Cubiculo
    public GameObject canvasInnovacion; // Canvas del nombre del modelo Inovacion
    public GameObject canvasLaboratorio; // Canvas del nombre del modelo laboratorio
    public Animator animadorAula; // Animacion del nombre del modelo Aula 
    public Animator animadorAuditorio; // Animacion del nombre del modelo Auditorio 
    public Animator animadorBiblioteca; // Animacion del nombre del modelo Biblioteda
    public Animator animadorCafeteria; // Animacion del nombre del modelo Cafetaria
    public Animator animadorCancha; // Animacion del nombre del modelo Cancha 
    public Animator animadorColiseo; // AnimadorCancha del nombre del modelo Coliceo 
    public Animator animadorCubiculo; // Animacion del nombre del modelo Cubiculo
    public Animator animadorInnovacion; // Animacion del nombre del modelo Innovacion
    public Animator animadorLaboratorio; // Animacion del nombre del modelo laboratorio
    public GameObject nombreBoton; // Nombre del botón activar / desactivar
    bool activado; // Variable del botón activar / desactivar

    // Función que se ejecuta al iniciar la aplicación y en su primer frame
    void Start()
    {
        /* Al iniciar la ejecución se ocultan todas los paneles de nombres */
        canvasAula.SetActive(false); // Se desaactiva el canvas del aula 
        canvasAuditorio.SetActive(false); // Se desactiva el canvas del Auditorio
        canvasBiblioteca.SetActive(false); // Se desactiva el canvas de la Biblioteca
        canvasCafeteria.SetActive(false); // Se desactiva el canvas de la Cafetaria
        canvasCancha.SetActive(false); // Se desactiva el canvas de la Cancha
        canvasColiseo.SetActive(false); // Se desactiva el canvas del Coliceo
        canvasCubiculo.SetActive(false); // Se desactiva el canvas del Cubiculo
        canvasInnovacion.SetActive(false); // Se desactiva el canvas del salon de Inovacion
        canvasLaboratorio.SetActive(false); // Se desactiva el canvas del Laboratorio
        activado = true; // Variable del boton activa/desactivar
    }

    // Función que reproduce el timeline de los nombres del croquis
    public void ReproducirCroquis()
    {
        /* Se reproduce la animación de apertura en los paneles de nombres */
        timeline.Play();
    }

    // Función que ejecuta la corrutina de mostrar u ocultar el nombre de los paneles
    public void mostrar_ocultarNombres()
    {
        /* Corutina para esperar unos segundos y no desaparezca el panel antes de poder volver a activar el botón */
        StartCoroutine(nombresSegundos());
    }

    /* Función que permite esperar unos segundos */
    IEnumerator nombresSegundos()
    {
        /* Se comprueba que se haya activado el botón, se muestran los paneles */
        if (activado)
        {
            canvasAula.SetActive(true); // Se activa el canvas del Aula
            canvasAuditorio.SetActive(true); // Se activa el canvas del Laboratorio
            canvasBiblioteca.SetActive(true); // Se activa el canvas de la biblioteca
            canvasCafeteria.SetActive(true); // Se activa el canvas de la Cafetaria
            canvasCancha.SetActive(true); // Se activa el canvas dela Cancha 
            canvasColiseo.SetActive(true); // Se activa el canvas del coliseo
            canvasCubiculo.SetActive(true); // Se activa del canvas cubiculo
            canvasInnovacion.SetActive(true); // Se activa el canvas de la Inovacion
            canvasLaboratorio.SetActive(true); // Se activa el canvas del laboratorio
            TMP_Text textoBoton = nombreBoton.GetComponent<TMP_Text>(); // Se obtiene el texto del botón
            textoBoton.text = "Desactivar"; // Se le coloca el texto para desactivar
            activado = false; // Variable del boton activa/desactivar
        }
        /* De otra forma se desactivo el botón, se dejan de mostrar los paneles */
        else
        {
            animadorAula.SetTrigger("TriggerAula"); // Desencadenador de la animacion Aula
            animadorAuditorio.SetTrigger("TriggerAuditorio"); // Desencadenador de la animacion Auditorio
            animadorBiblioteca.SetTrigger("TriggerBiblioteca"); // Desencadenador de la animacion Biblioteca
            animadorCafeteria.SetTrigger("TriggerCafeteria"); // Desencadenador de la animacion Cafeteria
            animadorCancha.SetTrigger("TriggerCancha"); // Desencadenador de la animacion Cancha 
            animadorColiseo.SetTrigger("TriggerColiseo"); // Desencadenador de la animacion Coliseo
            animadorCubiculo.SetTrigger("TriggerCubiculo"); // Desencadenador de la animacion Cubiculo
            animadorLaboratorio.SetTrigger("TriggerLaboratorio"); // Desencadenador de la animacion laboratorio
            animadorInnovacion.SetTrigger("TriggerInnovacion"); // Desencadenador de la animacion Inovacion
            yield return new WaitForSeconds(2); // Esperar 1 Segundo
            canvasAula.SetActive(false); // Se desactiva el canvas del Aula
            canvasAuditorio.SetActive(false); // Se desactiva el canvas del Auditorio
            canvasBiblioteca.SetActive(false); // Se desactiva el canvas de la Biblioteca
            canvasCafeteria.SetActive(false); // Se desactiva el canvas de la Cafetaria
            canvasCancha.SetActive(false); // Se desactiva el canvas de la Cancha
            canvasColiseo.SetActive(false); // Se desactiva el canvas del Coliseo
            canvasCubiculo.SetActive(false); // Se desactiva el canvas del Cubiculo
            canvasInnovacion.SetActive(false); // Se desactiva el canvas de Innovacion
            canvasLaboratorio.SetActive(false); // Se desactiva el canvas del Laboratorio
            TMP_Text textoBoton = nombreBoton.GetComponent<TMP_Text>(); // Se obtiene el texto del botón
            textoBoton.text = "Activar"; // Se le coloca el texto para activar
            activado = true; // Variable del boton activar / desactivar
        }
    }

    // Función que se ejecuta y actualiza cada frame que la aplicación se ejecute
    void Update()
    {
        transformAula.transform.LookAt(arCamera); // Gira la transformación para que el vector de avance apunte a la posición actual de la camara.
        transformAuditorio.transform.LookAt(arCamera); // Gira la transformación para que el vector de avance apunte a la posición actual de la camara.
        transformBiblioteca.transform.LookAt(arCamera); // Gira la transformación para que el vector de avance apunte a la posición actual de la camara.
        transformCafeteria.transform.LookAt(arCamera); // Gira la transformación para que el vector de avance apunte a la posición actual de la camara.
        transformCancha.transform.LookAt(arCamera); // Gira la transformación para que el vector de avance apunte a la posición actual de la camara.
        transformColiseo.transform.LookAt(arCamera); // Gira la transformación para que el vector de avance apunte a la posición actual de la camara.
        transformCubiculo.transform.LookAt(arCamera); // Gira la transformación para que el vector de avance apunte a la posición actual de la camara.
        transformInnovacion.transform.LookAt(arCamera); // Gira la transformación para que el vector de avance apunte a la posición actual de la camara.
        transformLaboratorio.transform.LookAt(arCamera); // Gira la transformación para que el vector de avance apunte a la posición actual de la camara.

        transformAula.transform.rotation *= Quaternion.Euler(0, 180, 0); // Rotar el panel aula 180 grados 
        transformAuditorio.transform.rotation *= Quaternion.Euler(0, 180, 0); // Rotar el panel auditorio 180 grados
        transformBiblioteca.transform.rotation *= Quaternion.Euler(0, 180, 0); // Rotar el panel biblioteca 180 grados
        transformCafeteria.transform.rotation *= Quaternion.Euler(0, 180, 0); // Rotar el panel cafeteria 180 grados
        transformCancha.transform.rotation *= Quaternion.Euler(0, 180, 0); // Rotar el panel cancha 180 grados
        transformColiseo.transform.rotation *= Quaternion.Euler(0, 180, 0); // Rotar el panel coliseo 180 grados
        transformCubiculo.transform.rotation *= Quaternion.Euler(0, 180, 0); // Rotar el panel cubiculo 180 grados
        transformInnovacion.transform.rotation *= Quaternion.Euler(0, 180, 0); // Rotar el panel inovacion 180 grados
        transformLaboratorio.transform.rotation *= Quaternion.Euler(0, 180, 0); // Rotar el panel laboratorio 180 grados
    }
}
