using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class MenuEdicioDinamic : MonoBehaviour
{
    static readonly char separator = Path.DirectorySeparatorChar;

    public static string rutaUlls = "Assets" + separator + "Content" + separator + "Sprites" + separator + "PersonatgePrincipal" + separator + "Ulls";
    private static string[] ulls = Directory.GetFiles(rutaUlls, "*.png");
    public static string rutaRoba = "Assets" + separator + "Content" + separator + "Sprites" + separator + "PersonatgePrincipal" + separator + "Roba";
    private static string[] roba = Directory.GetFiles(rutaRoba, "*.png");
    public static string rutaCabells = "Assets" + separator + "Content" + separator + "Sprites" + separator + "PersonatgePrincipal" + separator + "Cabells";
    private static string[] diferentCabell = Directory.GetDirectories(rutaCabells);
    private static string[] colorCabell = Directory.GetFiles(diferentCabell[1]);

    private static Rect mesures;
    private static Vector2 posicio;
    private static Vector4 tamany;



    // public static Sprite ullsSprite;
    private int opcioUlls = 0;
    private int opcioRoba = 0;
    private int opcioCabell = 0;
    private int opcioColorCabell = 0;
    public void SeguentCabell()
    {
        if (opcioCabell + 1 == diferentCabell.Length)
        {
            opcioCabell = 0;
        }
        else
        {
            opcioCabell++;
        }
        opcioColorCabell = 0;
        canviApariencia();
    }
    public void SeguentColor()
    {
        if (opcioColorCabell + 1 == colorCabell.Length)
        {
            opcioColorCabell = 0;
        }
        else
        {
            opcioColorCabell++;
        }
        canviApariencia();
    }
    public void SeguentUlls()
    {
        if (opcioUlls + 1 == ulls.Length)
        {
            opcioUlls = 0;
        }
        else
        {
            opcioUlls++;
        }
        canviApariencia();

    }
    public void AnteriorUlls()
    {
        if (opcioUlls - 1 == -1)
        {
            opcioUlls = ulls.Length - 1;
        }
        else
        {
            opcioUlls--;
        }
        canviApariencia();
    }
    public void SeguentRoba()
    {
        if (opcioRoba + 1 == roba.Length)
        {
            opcioRoba = 0;
        }
        else
        {
            opcioRoba++;
        }
        canviApariencia();


    }
    public void AnteriorRoba()
    {
        if (opcioRoba - 1 == -1)
        {
            opcioRoba = roba.Length - 1;
        }
        else
        {
            opcioRoba--;
        }
        canviApariencia();
    }
    public void canviApariencia()
    {
        colorCabell = Directory.GetFiles(diferentCabell[opcioCabell], "*.png");
        Texture2D texturaCabell = new Texture2D(0, 0);
        Texture2D texturaUll = new Texture2D(0, 0);
        Texture2D texturaRoba = new Texture2D(0, 0);

        byte[] pngCabell = File.ReadAllBytes(colorCabell[opcioColorCabell]);
        byte[] pngUll = File.ReadAllBytes(ulls[opcioUlls]);
        byte[] pngRoba = File.ReadAllBytes(roba[opcioRoba]);
        texturaUll.LoadImage(pngUll);
        texturaRoba.LoadImage(pngRoba);
        texturaCabell.LoadImage(pngCabell);

        //public static Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border, bool generateFallbackPhysicsShape);
        Vector2 posiciofinal = posicio;

        Sprite CabellSprite = Sprite.Create(texturaCabell, mesures, posiciofinal, 1, 1, SpriteMeshType.FullRect, tamany, true);
        Sprite ullsSprite = Sprite.Create(texturaUll, mesures, posiciofinal, 1, 1, SpriteMeshType.FullRect, tamany, true);
        Sprite robaSprite = Sprite.Create(texturaRoba, mesures, posiciofinal, 1, 1, SpriteMeshType.FullRect, tamany);
        ullsSprite.texture.filterMode = FilterMode.Point;
        robaSprite.texture.filterMode = FilterMode.Point;
        CabellSprite.texture.filterMode = FilterMode.Point;

        //ullsSprite.texture.alphaIsTransparenc
        // robaSprite.texture.filterMode = FilterMode.Point;
        GameObject.Find("Ulls").GetComponent<SpriteRenderer>().sprite = ullsSprite;
        //GameObject.Find("Ulls").GetComponent<SpriteRenderer>().spriteSortPoint = SpriteSortPoint.Pivot;
        GameObject.Find("Roba").GetComponent<SpriteRenderer>().sprite = robaSprite;
        GameObject.Find("Cabell").GetComponent<SpriteRenderer>().sprite = CabellSprite;
        //GameObject.Find("Roba").GetComponent<SpriteRenderer>().spriteSortPoint = SpriteSortPoint.Center;
        GameObject.Find("CreaAnimacions").GetComponent<CreaAnimacions>().rutes[0] = ulls[opcioUlls];
        GameObject.Find("CreaAnimacions").GetComponent<CreaAnimacions>().rutes[1] = "Assets" + separator + "Content" + separator + "Sprites" + separator + "PersonatgePrincipal" + separator + "Base" + separator + "cuerpo.png";
        GameObject.Find("CreaAnimacions").GetComponent<CreaAnimacions>().rutes[2] = colorCabell[opcioColorCabell];
        GameObject.Find("CreaAnimacions").GetComponent<CreaAnimacions>().rutes[3] = roba[opcioRoba];



    }

    void Update()
    {

    }
    private void Start()
    {
        opcioColorCabell = 0;
        /*TextureImporter ti = AssetImporter.GetAtPath(ulls[opcioUlls]) as TextureImporter;
        ti.isReadable = true;
        List<SpriteMetaData> newData = new List<SpriteMetaData>();*/
        //Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border);
        TextureImporter ti = AssetImporter.GetAtPath("Assets" + separator + "Content" + separator + "Sprites" + separator + "PersonatgePrincipal" + separator + "Base" + separator + "base.png") as TextureImporter;
        ti.isReadable = true;
        mesures = ti.spritesheet[1].rect;//GameObject.Find("Ulls").GetComponent<SpriteRenderer>().sprite.rect;
        posicio = ti.spritesheet[1].pivot;//GameObject.Find("Ulls").GetComponent<SpriteRenderer>().sprite.pivot;
                                          //Boolean a = GameObject.Find("Ulls").GetComponent<SpriteRenderer>().sprite.packed;
        tamany = ti.spritesheet[1].border;//GameObject.Find("Base").GetComponent<SpriteRenderer>().sprite.border; 
        canviApariencia();

    }

}
