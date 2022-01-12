using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Nou Text", menuName = "TextDialeg")]
public class TextDialeg : ScriptableObject
{
    public string[] text;
    public int soPerChar = 3;
    public double velocitatParla = 0.025;
    public ActorDialeg actor;
}
