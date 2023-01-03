using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private RectTransform rectComponent;
    private Image imageComp;
    private bool up;

    public float rotateSpeed = 200f; // Se establece una velocidad de rotación
    public float openSpeed = .005f; // Se establece una velocidad de apertura
    public float closeSpeed = .01f; // Se establece una velocidad de cerradura

    // Función que se ejecuta al iniciar la aplicación y en su primer frame
    private void Start()
    {
        rectComponent = GetComponent<RectTransform>(); // rectComponent se le asigna una referencia al componente RectTransform adjunto al GameObject 
        imageComp = rectComponent.GetComponent<Image>(); // La función GetComponent se usa nuevamente, esta vez para recuperar una referencia al Imagecomponente adjunto al GameObject
        up = true; // Se declara la variable up como true
    }

    // Función que se ejecuta y actualiza cada frame que la aplicación se ejecute
    private void Update()
    {
        // En el eje z esta predeterminado por la variable rotateSpeed que se mutiplica Time.deltaTime 
        rectComponent.Rotate(0f, 0f, rotateSpeed * Time.deltaTime); // rectComponent llama al metodo Rotate con 'x' y 'y' en cero
        changeSize(); // Se manda llamar la función changeSize()
    }

    // Funcion que modifica la propiedad de fillAmount de image
    private void changeSize()
    {
        // Esta funcion alterna entre aumentar y disminuir la propiedad fillAmount para animar el llenado y vaciado de la imagen
        float currentSize = imageComp.fillAmount;

        if (currentSize < .30f && up)
        {
            imageComp.fillAmount += openSpeed;
        }
        else if (currentSize >= .30f && up)
        {
            up = false;
        }
        else if (currentSize >= .02f && !up)
        {
            imageComp.fillAmount -= closeSpeed;
        }
        else if (currentSize < .02f && !up)
        {
            up = true;
        }
    }
}