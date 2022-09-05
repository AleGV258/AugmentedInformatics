using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraVirtual : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject canvasPantallas;
    bool encontrado;
    float camaraX, camaraY, camaraZ, canvasX, canvasY, canvasZ;
    //public GameObject nuevoScript;

    void Start()
    {
        arCamera = GameObject.Find("ARCamera");
        canvasPantallas = GameObject.Find("CanvasRealidadVirtual");
    }

    public void targetEncontrado()
    {
        encontrado = true;
        //camaraX = arCamera.transform.position.x;
        //camaraY = arCamera.transform.position.y;
        //camaraZ = arCamera.transform.position.z;
        //canvasX = canvasPantallas.transform.position.x;
        //canvasY = canvasPantallas.transform.position.y;
        //canvasZ = canvasPantallas.transform.position.z;
    }

    void Update()
    {
        //camaraX = arCamera.transform.position.x;
        //camaraY = arCamera.transform.position.y;
        //camaraZ = arCamera.transform.position.z;
        //canvasX = canvasPantallas.transform.position.x;
        //canvasY = canvasPantallas.transform.position.y;
        //canvasZ = canvasPantallas.transform.position.z;


        //Debug.Log(arCamera.transform.position.ToString());
        //Debug.Log(canvasPantallas.transform.position.ToString());
        //Debug.Log(nuevoScript.GetComponent<ScriptPantallas>().prueba.ToString());
        //Debug.Log("Camara X " + camaraX.ToString());
        //Debug.Log("Camara Y " + camaraY.ToString());
        //Debug.Log("Camara Z " + camaraZ.ToString());
        //Debug.Log("Canvas X " + canvasX.ToString());
        //Debug.Log("Canvas Y " + canvasY.ToString());
        //Debug.Log("Canvas Z " + canvasZ.ToString());
        if (encontrado)
        {
            //canvasPantallas.transform.position = new Vector3(camaraX+5.0f, camaraY, camaraZ);
        }
    }
}
