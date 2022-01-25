using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //CONTROL EVENTS DEL GAMEMANAGER
    public static GameManager instance;
    public List<Event> eventsExecutar = new List<Event>();
    private List<int> estatAccio = new List<int>();
    private bool accioentrant = false;

    // CONTROL DIALEG
    private int textActual;
    public bool estaLlegint;

    // COMPONENTS
    public TMP_Text texto;
    public GameObject panel;
    public AudioSource audioPanel;


    public void Awake()
    {
        accioentrant = true;
        instance = this;
    }

    /**
     * S'executarà quan es volguin cridar events desde un Colisable
     */
    public void runEvent(Event evento) {
        accioentrant = true;
        eventsExecutar.Add(evento);
        estatAccio.Add(0);
    }
    void gestioDialegs() {
        Dialeg dialeg = (Dialeg)eventsExecutar[eventsExecutar.Count - 1].accions[estatAccio[eventsExecutar.Count - 1]];
        if (!estaLlegint)
        {
            ComencarConversa(dialeg);
        }
        else if (texto.text == dialeg.dialeg[textActual].text[0])
        {
            SeguentLinea(dialeg);
            
        }
        else
        {
            StopAllCoroutines();
            texto.text = dialeg.dialeg[textActual].text[0];
            if (textActual + 1 == dialeg.dialeg.Length)
            {
                estatAccio[eventsExecutar.Count - 1]++;
                controlFinalitzacioEvent();
            }
        }
    }
    public void SeguentLinea(Dialeg dialeg)
    {
        textActual++;
        StartCoroutine(MostrarLinea(dialeg));

    }
    public void ComencarConversa(Dialeg dialeg)
    {
        panel.active = true;
        estaLlegint = true;
        StartCoroutine(MostrarLinea(dialeg));
    }
    public IEnumerator MostrarLinea(Dialeg dialeg)
    {
        int parlar = 0;
        texto.text = "";
        foreach (char ch in dialeg.dialeg[textActual].text[0])
        {
            texto.text += ch;
            if (ch == ',')
            {
                yield return new WaitForSeconds((float)dialeg.dialeg[textActual].velocitatParla * 8);
            }
            else if (ch == '.' || ch == '!' || ch == '?')
            {
                yield return new WaitForSeconds((float)dialeg.dialeg[textActual].velocitatParla * 12);
            }
            else
            {
                yield return new WaitForSeconds((float)dialeg.dialeg[textActual].velocitatParla);
            }
            if (parlar % dialeg.dialeg[textActual].soPerChar == 0)
            {
                audioPanel.PlayOneShot(dialeg.dialeg[textActual].actor.veuPersonatge);
            }
            parlar++;
        }
        if (textActual + 1 == (dialeg.dialeg.Length))
        {
            estatAccio[eventsExecutar.Count - 1]++;
            controlFinalitzacioEvent();
        }
    }
    //public void canviaEstats(Event evento) {
    //    foreach (GameObject objeto in evento.estatsAfectats)
    //    {
    //        objeto.GetComponent<Colisionable>().estat = evento.estatModificar;
    //    }
    //}
    public void controlFinalitzacioEvent() {
        if (eventsExecutar[eventsExecutar.Count - 1].accions.Length == estatAccio[eventsExecutar.Count - 1]) {

            canviaEstats();

            estatAccio.RemoveAt(eventsExecutar.Count - 1);
            eventsExecutar.RemoveAt(eventsExecutar.Count - 1);
            estaLlegint = false;
            textActual = 0;
        }
    }
    private void Update()
    {
        //EXECUTA EN CAS DE QUE HI HAGI ALGUN EVENT A LA CUA O S'EXECUTI ALGUNA INTERACCIÓ
        if (eventsExecutar.Count > 0 && Input.GetButtonDown("Jump") | accioentrant)
        {
            accioentrant = false;
            if (eventsExecutar[eventsExecutar.Count - 1].accions[estatAccio[eventsExecutar.Count - 1]] is Dialeg)
            {
                gestioDialegs();
            }
        }
        // EXECUTA EN CAS DE QUE NO HI HAGI CAP ELEMENT EN LA CUA 
        else if (eventsExecutar.Count == 0 && Input.GetButtonDown("Jump")) {
            panel.active = false;
            texto.text = "";
            textActual = 0;
            estaLlegint = false;
        }
    }
    private void canviaEstats () {
        foreach (string gO in eventsExecutar[eventsExecutar.Count - 1].estatsAfectats) {
           GameObject.Find(gO).GetComponent<Colisionable>().estat = eventsExecutar[eventsExecutar.Count - 1].estatModificar;
        }    
    }
}
