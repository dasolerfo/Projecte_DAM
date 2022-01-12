using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PassarPersonatge : MonoBehaviour
{
    public GameObject personatge;
    
    public void acabar()
    {
        print("hola");
        PrefabUtility.SaveAsPrefabAsset(personatge, "Assets/Content/Sprites/PersonatgePrincipal/PersonatgeFinal.prefab");
        PrefabUtility.SaveAsPrefabAsset(GameObject.Find("CreaAnimacions"), "Assets/Content/Scenes/CreaAnimacions.prefab");

        SceneManager.LoadScene(1);
        //GameObject.Find("PersonatgeFinal").GetComponent<CreaAnimacions>().prova();
    }
}
