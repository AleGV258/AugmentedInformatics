using UnityEngine;
using UnityEngine.Playables;

public class SubirCroquis : MonoBehaviour
{
    public PlayableDirector timeline;

    public void ReproducirCroquis()
    {
        timeline.Play();
    }
}
