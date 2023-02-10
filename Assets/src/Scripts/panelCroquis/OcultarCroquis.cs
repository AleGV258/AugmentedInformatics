using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OcultarCroquis : MonoBehaviour
{
    public GameObject I; // GameObject de la imagen del edificio Innovación
    public GameObject D; // GameObject de la imagen del edificio Laboratorios
    public GameObject B; // GameObject de la imagen del edificio Biblioteca
    public GameObject A; // GameObject de la imagen del edificio Aulas

    // Start is called before the first frame update
    void Start()
    {
        I.SetActive(false); // Se desactiva la imagen
        D.SetActive(false); // Se desactiva la imagen
        A.SetActive(true); // Se activa la imagen
        B.SetActive(false); // Se desactiva la imagen
    }
}
