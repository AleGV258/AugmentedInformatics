using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mostrarEdificioD : MonoBehaviour
{
    public GameObject D;
    public void mostrarObjeto()
    {
        if (D.activeSelf == false)
            D.SetActive(true);
        else
            D.SetActive(false);
    }   
}
