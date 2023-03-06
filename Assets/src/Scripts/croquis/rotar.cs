using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotar : MonoBehaviour
{
    public float speed = 0.1f; // Velocidad de rotación del objeto
    void Update()
    {
        
        int nbTouches = Input.touchCount;
        if (nbTouches > 0)
        {
            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);
                TouchPhase phase = touch.phase;
                switch (phase)
                {
                    case TouchPhase.Began:
                        break;
                    case TouchPhase.Moved:
                        transform.Rotate(new Vector3(touch.deltaPosition.y * speed, touch.deltaPosition.x * speed));
                        break;
                    case TouchPhase.Ended:
                        break;
                }
            }
        }
        
        // transform.Rotate(new Vector3(Time.deltaTime*x, Time.deltaTime*y, Time.deltaTime*z)); // Rotar el GameObject automáticamente
    }

    void LateUpdate()
    {
        Quaternion rotation = transform.rotation;
        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = rotation;
    }
}
