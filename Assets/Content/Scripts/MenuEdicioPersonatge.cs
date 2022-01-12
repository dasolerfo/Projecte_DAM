using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuEdicioPersonatge : MonoBehaviour
{
    [Header("Sprites Cyle To Change")]
    public List<Sprite> cabell = new List<Sprite>();
    public List<Sprite> cabellColor = new List<Sprite>();
    private int opcioCabell = 0;
    private int opcioCabellColor = 0;
    private int opcioCabellColor1 = 6;
    

    public void SeguentOpcio()
    {
        opcioCabell++;
        if(opcioCabell >= cabell.Count)
        {
            opcioCabell = 0;
        }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = cabell[opcioCabell];
    }
    public void AnteriorOpcio()
    {
        opcioCabell--;
        if (opcioCabell <= 0)
        {
            opcioCabell = cabell.Count - 1;
        }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = cabell[opcioCabell];
    }
    public void SeguentOpcioColor()
    {
        if(opcioCabell == 0)
        {
            opcioCabellColor++;
            if (opcioCabellColor == 6)
            {
                opcioCabellColor = 0;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cabellColor[opcioCabellColor];
        }else if (opcioCabell == 1)
        {
            opcioCabellColor1++;
            if (opcioCabellColor1 == 12)
            {
                opcioCabellColor1 = 6;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cabellColor[opcioCabellColor1];
        }
    }
    public void AnteriorOpcioColor()
    {
        if (opcioCabell == 0)
        {
            opcioCabellColor--;
            if (opcioCabellColor <= 0)
            {
                opcioCabellColor = 5;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cabellColor[opcioCabellColor];
        }else if(opcioCabell == 1)
        {
            opcioCabellColor1--;
            if (opcioCabellColor1 <= 7)
            {
                opcioCabellColor1 = 12;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cabellColor[opcioCabellColor1];
        }
    }
    
}
