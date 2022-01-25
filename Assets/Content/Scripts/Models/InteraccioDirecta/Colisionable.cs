using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//[CreateAssetMenu(fileName = "New EstatNPC", menuName = "EstatNPC")]
public class Colisionable : MonoBehaviour
{
    public int estat;
    public Event[] events;
    private bool dins;
    private bool interectuant;
    private int controlLlistaEvents;
 
    private void Update()
    {

        if (dins && Input.GetButtonDown("Jump") && GameManager.instance.eventsExecutar.Count == 0) {
            gestioEvents();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         dins = true;
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        dins = false;
    }
    private void gestioEvents() {
       // EN CAS DE QUE NO HAGI BUSCAT EN TOTS ELS EVENTS DE LA LLISTA EXECUTARA LA CERCA, O SINO RESETEJA LA CUA
        if (controlLlistaEvents < events.Length)
        {
            for (int i = controlLlistaEvents; i < events.Length; i++)
            {
                if (events[i].estat[0] == estat)
                {
                    controlLlistaEvents = i + 1;
                    GameManager.instance.runEvent(events[i]);
                    break;
                }
                if (i == events.Length - 1)
                {
                    controlLlistaEvents = 0;
                }
            }
        }
        else {
            controlLlistaEvents = 0;
        }

    }
}
