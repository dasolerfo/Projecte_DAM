using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "Event")]
public class Event : ScriptableObject
{
    public int[] estat;
    public string nom;
    public Accio[] accions;
    public string[] estatsAfectats;
    public int estatModificar;
}
