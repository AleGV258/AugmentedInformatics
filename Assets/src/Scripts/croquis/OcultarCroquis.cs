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
    public GameObject Mapa; // GameObject de la imagen del mapa de la facultad
    public GameObject banderaI; // GameObject de la bandera del edificio de Innovación
    public GameObject banderaD; // GameObject de la bandera del edificio de Laboratorios
    public GameObject banderaB; // GameObject de la bandera del edificio de Biblioteca
    public GameObject banderaA; // GameObject de la bandera del edificio de Aulas

    // Función que se ejecuta al iniciar la aplicación y en su primer frame
    void Start()
    {
        I.SetActive(true); // Se activa la imagen
        D.SetActive(true); // Se activa la imagen
        A.SetActive(true); // Se activa la imagen
        B.SetActive(true); // Se activa la imagen
        I.SetActive(false); // Se desactiva la imagen
        D.SetActive(false); // Se desactiva la imagen
        A.SetActive(false); // Se desactiva la imagen
        B.SetActive(false); // Se desactiva la imagen
        Mapa.SetActive(true); // Se activa la imagen
        banderaI.SetActive(true); // Se activa la bandera del edificio de Innovación
        banderaD.SetActive(true); // Se activa la bandera del edificio de Laboratorios
        banderaB.SetActive(true); // Se activa la bandera del edificio de Biblioteca
        banderaA.SetActive(true); // Se activa la bandera del edificio de Aulas
        banderaI.SetActive(false); // Se desactiva la bandera del edificio de Innovación
        banderaD.SetActive(false); // Se desactiva la bandera del edificio de Laboratorios
        banderaB.SetActive(false); // Se desactiva la bandera del edificio de Biblioteca
        banderaA.SetActive(false); // Se desactiva la bandera del edificio de Aulas
    }

    // Función que activa el GameObject de aula y desactiva los demás
    public void activarAulas(){
        I.SetActive(false); // Se desactiva la imagen
        D.SetActive(false); // Se desactiva la imagen
        A.SetActive(true); // Se activa la imagen
        B.SetActive(false); // Se desactiva la imagen
        Mapa.SetActive(false); // Se desactiva la imagen
        banderaA.SetActive(true); // Se activa la bandera del edificio de Aulas
        banderaI.SetActive(false); // Se desactiva la bandera del edificio de Innovación
        banderaD.SetActive(false); // Se desactiva la bandera del edificio de Laboratorios
        banderaB.SetActive(false); // Se desactiva la bandera del edificio de Biblioteca
    }

    // Función que activa el GameObject de biblioteca y desactiva los demás
    public void activarBiblioteca(){
        I.SetActive(false); // Se desactiva la imagen
        D.SetActive(false); // Se desactiva la imagen
        A.SetActive(false); // Se desactiva la imagen
        B.SetActive(true); // Se activa la imagen
        Mapa.SetActive(false); // Se desactiva la imagen
        banderaB.SetActive(true); // Se activa la bandera del edificio de Biblioteca
        banderaI.SetActive(false); // Se desactiva la bandera del edificio de Innovación
        banderaD.SetActive(false); // Se desactiva la bandera del edificio de Laboratorios
        banderaA.SetActive(false); // Se desactiva la bandera del edificio de Aulas
    }

    // Función que activa el GameObject de laboratorio y desactiva los demás
    public void activarLaboratorios(){
        I.SetActive(false); // Se desactiva la imagen
        D.SetActive(true); // Se activa la imagen
        A.SetActive(false); // Se desactiva la imagen
        B.SetActive(false); // Se desactiva la imagen
        Mapa.SetActive(false); // Se desactiva la imagen
        banderaD.SetActive(true); // Se activa la bandera del edificio de Laboratorios
        banderaI.SetActive(false); // Se desactiva la bandera del edificio de Innovación
        banderaB.SetActive(false); // Se desactiva la bandera del edificio de Biblioteca
        banderaA.SetActive(false); // Se desactiva la bandera del edificio de Aulas
    }

    // Función que activa el GameObject de inovacion y desactiva los demás
    public void activarInovacion(){
        I.SetActive(true); // Se activa la imagen
        D.SetActive(false); // Se desactiva la imagen
        A.SetActive(false); // Se desactiva la imagen
        B.SetActive(false); // Se desactiva la imagen
        Mapa.SetActive(false); // Se desactiva la imagen
        banderaI.SetActive(true); // Se activa la bandera del edificio de Innovación
        banderaD.SetActive(false); // Se desactiva la bandera del edificio de Laboratorios
        banderaB.SetActive(false); // Se desactiva la bandera del edificio de Biblioteca
        banderaA.SetActive(false); // Se desactiva la bandera del edificio de Aulas
    }
}
