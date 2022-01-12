using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionaEvents : MonoBehaviour
{
    public AudioSource gestionaAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ExecutaEvents(Event eventExecutar) {
        foreach (Accio accion in eventExecutar.accions) {
            if (accion is Dialeg) { 
            }
        }
    }
}
