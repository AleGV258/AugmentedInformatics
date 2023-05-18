using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botonRegresar : MonoBehaviour
{
    public Button bottonRegresar;

    void Start()
    {
        
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape)){
            bottonRegresar.onClick.Invoke();
            // if (Input.GetKey(KeyCode.Escape)){     
            //     return;
            // }
        }
    }
}
