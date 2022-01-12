using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

//using Unity.Animations;

[RequireComponent(typeof(Animation))]
public class CreaAnimacions : MonoBehaviour
{

    public string[] rutes;
    public string rutaJugador = "Assets\\Content\\Animations\\Player";
    public AnimationClip animacioImportar;
    private string[] nomsAnimacions = { "_abaix.anim", "_abaix_parat.anim", "_esquerra.anim", "_esquerra_parat.anim", "_dreta.anim", "_dreta_parat.anim", "_amunt.anim", "_amunt_parat.anim" };
    private string[] nomsCarpetes = { "Ulls", "Base", "Cabell", "Roba" };
    private int[][] numSprite = { new int[] { 0,1,2} , new int[] { 1,1,1}, new int[] { 3,4,5 }, new int[] { 4, 4, 4}, new int[] { 6,7,8 }, new int[] { 7, 7, 7 }, new int[] { 9, 10, 11 }, new int[] { 10,10,10}  };

    void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals("MenuPersonatge") ) {
            CreateSpriteAnimationClip();
        }
        //rutes = new string[] { "", "Assets\\Content\\Sprites\\PersonatgePrincipal\\Base\\base.png", "Assets/Content/Sprites/PersonatgePrincipal/Cabells/Cabell1/peloChico1.1.png", ""};
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateSpriteAnimationClip()
    {
        for (int i = 0; i < nomsCarpetes.Length; i++) {
            for (int y = 0; y < nomsAnimacions.Length; y++) {
                
                List<Sprite> sprites = generaSprite(i,y);

                GameObject.Find("PersonatgeFinal").GetComponent<PlayerMoviment>().animacioMoviment[i, y, 0] = sprites[0];
                GameObject.Find("PersonatgeFinal").GetComponent<PlayerMoviment>().animacioMoviment[i, y, 1] = sprites[1];
                GameObject.Find("PersonatgeFinal").GetComponent<PlayerMoviment>().animacioMoviment[i, y, 2] = sprites[2];

                /* int framecount = sprites.Count;
                 float frameLength = 1f / 30f;

                 AnimationClip clip = new AnimationClip();
                 clip.frameRate = fps;

                 AnimationUtility.GetAnimationClipSettings(clip).loopTime = true;

                 EditorCurveBinding curveBinding = new EditorCurveBinding();
                 curveBinding.type = typeof(SpriteRenderer);
                 curveBinding.propertyName = "m_Sprite";

                 ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[framecount];

                 for (int j = 0; j < framecount; j++)
                 {
                     ObjectReferenceKeyframe kf = new ObjectReferenceKeyframe();
                     kf.time = j * frameLength;
                     kf.value = sprites[j];
                     keyFrames[j] = kf;
                 }

                 clip.name = name;
                 //AnimationUtility.SetAnimationType(clip, ModelImporterAnimationType.Legacy);
                 clip.legacy = true;
                 Debug.Log(clip.wrapMode);
                 clip.wrapMode = WrapMode.Clamp;

                 //setAnimationLoop(clip);
                 AnimationUtility.SetObjectReferenceCurve(clip, curveBinding, keyFrames);
                 //clip.legacy = true;
                 GameObject.Find(nomsCarpetes[i]).GetComponent<Animation>().AddClip(clip, nomsCarpetes[i] + nomsAnimacions[y]);
                 if (File.Exists(rutaJugador + "\\" + nomsCarpetes[i] + "\\" + nomsCarpetes[i] + nomsAnimacions[y])) File.Delete(rutaJugador + "\\" + nomsCarpetes[i] + "\\" + nomsCarpetes[i] + nomsAnimacions[y]);
                 AssetDatabase.CreateAsset(clip, rutaJugador +"\\" + nomsCarpetes[i] + "\\" + nomsCarpetes[i] + nomsAnimacions[y]);
                 AssetDatabase.SaveAssets(); */

            }
        }
        GameObject.Find("PersonatgeFinal").GetComponent<PlayerMoviment>().enabled = true;
        //GameObject.Find("Fin").GetComponent<PassarPersonatge>().acabar();
        
        //List < Sprite > sprites = caminaAbaix();

    }
    public List<Sprite> generaSprite(int part, int direccio) {
        TextureImporter ti = AssetImporter.GetAtPath("Assets\\Content\\Sprites\\PersonatgePrincipal\\Base\\base.png") as TextureImporter;
        ti.isReadable = true;
        Texture2D texturaUll = new Texture2D(0, 0);
        byte[] pngUll = File.ReadAllBytes(rutes[part]);
        texturaUll.LoadImage(pngUll);
        List<Sprite> sprites = new List<Sprite>(3);
        texturaUll.filterMode = FilterMode.Point;
        sprites.Add(Sprite.Create(texturaUll, ti.spritesheet[numSprite[direccio][0]].rect, ti.spritesheet[0].pivot, 1, 1, SpriteMeshType.FullRect, ti.spritesheet[0].border, true));
        sprites.Add(Sprite.Create(texturaUll, ti.spritesheet[numSprite[direccio][1]].rect, ti.spritesheet[1].pivot, 1, 1, SpriteMeshType.FullRect, ti.spritesheet[1].border, true));
        sprites.Add(Sprite.Create(texturaUll, ti.spritesheet[numSprite[direccio][2]].rect, ti.spritesheet[2].pivot, 1, 1, SpriteMeshType.FullRect, ti.spritesheet[2].border, true));
       
        return sprites;
    }
}
