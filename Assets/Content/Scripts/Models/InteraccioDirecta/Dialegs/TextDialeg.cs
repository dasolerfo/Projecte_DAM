using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Text", menuName = "TextDialeg")]
public class TextDialeg : ScriptableObject
{
    [TextArea(1,4)]public string[] text =  new string[2] ;
    public int soPerChar = 3;
    public double velocitatParla = 0.025;
    public ActorDialeg actor;
}
