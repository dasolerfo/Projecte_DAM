using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//[CreateAssetMenu(fileName = "New EstatNPC", menuName = "EstatNPC")]
public class EstatNPC : MonoBehaviour
{
    public int estat;
    public Event[] events;
    private bool dins;
    private int textActual;
    public TMP_Text texto;
    public GameObject panel;
    public bool estaLlegint;
    public AudioSource audio;
    private void Update()
    {
        if (dins && Input.GetButtonDown("Jump")) {
            if (!estaLlegint)
            {
                ComencarConversa();
            }
            else if (texto.text == ((Dialeg)events[estat].accions[0]).dialeg[textActual].text[0])
            {

                SeguentLinea();
            }
            else {
                StopAllCoroutines();
                texto.text = ((Dialeg)events[estat].accions[0]).dialeg[textActual].text[0];
            }
        }
    }
    public void SeguentLinea() {

        textActual++;
        if (textActual < ((Dialeg)events[estat].accions[0]).dialeg.Length )
        {
           
            StartCoroutine(MostrarLinea());
        }
        else {
            panel.active = false;
            texto.text = "";
            textActual = 0;
            estaLlegint = false;
        }
    }
    public void ComencarConversa() {
        panel.active = true;
        estaLlegint = true;
        StartCoroutine(MostrarLinea());
    }
    public IEnumerator MostrarLinea() {
        int parlar = 0;
        texto.text = "";
        Dialeg dialeg = (Dialeg) events[estat].accions[0];
        foreach (char ch in dialeg.dialeg[textActual].text[0]) {
            texto.text += ch;
            if (ch == ',') 
            {
                yield return new WaitForSeconds((float)dialeg.dialeg[textActual].velocitatParla * 8); 
            }
            else if (ch == '.' || ch == '!' || ch == '?')
            {
                yield return new WaitForSeconds((float)dialeg.dialeg[textActual].velocitatParla * 12);
            }
            else {
                yield return new WaitForSeconds((float)dialeg.dialeg[textActual].velocitatParla);
            }
            if (parlar % dialeg.dialeg[textActual].soPerChar == 0) {
                audio.PlayOneShot(dialeg.dialeg[textActual].actor.veuPersonatge);
            }
            parlar++;
                
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
}
