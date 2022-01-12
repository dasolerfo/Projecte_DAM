using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float velocitat = 50f;
    private Rigidbody2D personatge;
    public int temporitzador = 0;
    public int framesAnimacio;
    public Sprite[,,] animacioMoviment = new Sprite[4, 8 , 3];
    public int ultim;
    public int moviment;

    //private Animator animator;
    Vector2 movement;
    // Start is called before the first frame update

    private void Start()
    {
        personatge = this.gameObject.GetComponent<Rigidbody2D>();
        //animator = this.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        temporitzador++;

        

     


        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);


    }
    int retornaSprite() {

            if (framesAnimacio > temporitzador )
            {
                return 1;
            }
            else if (framesAnimacio * 2 > temporitzador)
            {
                return 0;
            }
            else if (framesAnimacio * 3 > temporitzador)
            {
                return 1;
            }
            else if (framesAnimacio * 4 > temporitzador)
            {
                return 2;
            }
        else {
                temporitzador = 0;
                return 1;
            }
    }
    void FixedUpdate()
    {
        int estatAnimacio = retornaSprite();
        if (movement.x != 0 || movement.y != 0)
        {
            ultim = 0;
            if (movement.x == 1)
            { 
                moviment = 4;
                
               
            }
            else if (movement.x == -1)
            {
               
                moviment = 2;
                
            }
            else if (movement.y == 1)
            {
               
                moviment = 6;
                
            }
            else if (movement.y == -1)
            {
               
                moviment = 0;

            }
        }
        else
        {
            ultim = 1;
        }

        GameObject.Find("PersonatgeFinal").transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = animacioMoviment[0, moviment + ultim, estatAnimacio];
        GameObject.Find("PersonatgeFinal").transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = animacioMoviment[1, moviment + ultim, estatAnimacio];
        GameObject.Find("PersonatgeFinal").transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = animacioMoviment[2, moviment + ultim, estatAnimacio];
        GameObject.Find("PersonatgeFinal").transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = animacioMoviment[3, moviment + ultim, estatAnimacio];

        personatge.MovePosition(personatge.position + movement * (int)velocitat );
        personatge.rotation = 0 ;
    }
}
