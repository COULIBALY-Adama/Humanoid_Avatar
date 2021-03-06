using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int Speed = 5;
     public int RunSpeed = 10;
    private Vector3 DirectionDeplacement = Vector3.zero;
    private CharacterController Player;
    public int Sensi;
    public int Jump = 12;
    public int gravite = 20;
    private Animator Anim;

    // Use this for initialization
    void Start () {

        Player = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        DirectionDeplacement.z = Input.GetAxisRaw("Vertical");
        DirectionDeplacement.x = Input.GetAxisRaw("Horizontal");
        DirectionDeplacement = transform.TransformDirection(DirectionDeplacement);
        
        // Depacement
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Player.Move(DirectionDeplacement * Time.deltaTime * RunSpeed);
        }
        else
        {
            Player.Move(DirectionDeplacement * Time.deltaTime * Speed);
        }

        transform.Rotate(0, Input.GetAxisRaw("Mouse X")*Sensi, 0);

        //Saut
        if (Input.GetKeyDown(KeyCode.Space) && Player.isGrounded) // Space correspond au bouton de la souris
        {
            DirectionDeplacement.y = Jump;
            Anim.SetTrigger("Jumping");
        }

        // Gravité
        if(!Player.isGrounded)
        {
            DirectionDeplacement.y -= gravite * Time.deltaTime ;
        }

        //Animation
        if (Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("Walk", true);
            Anim.SetBool("Run", false);
            

        }

        if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("Walk", false);
            Anim.SetBool("Run", true);

        }

        if (!Input.GetKey(KeyCode.W))
        {
            Anim.SetBool("Walk", false);
            Anim.SetBool("Run", false);
           
        }
        // -----------------------
        if (Input.GetKey(KeyCode.Q) & !Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("Straf", true);
            Anim.SetBool("Walk", false);
            Anim.SetBool("Run", false);
        }

        if (!Input.GetKey(KeyCode.Q))
        {
            Anim.SetBool("Straf", false);         

        }
        //--------------------------
        if (Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("HalfG", true);
            Anim.SetBool("Walk", false);
            Anim.SetBool("Run", false);
        }
        
        if (!Input.GetKey(KeyCode.A))
        {
            Anim.SetBool("HalfG", false);
        }

        // ------------
        if (Input.GetKey(KeyCode.D) & !Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("HalfD", true);
            Anim.SetBool("Walk", false);
            Anim.SetBool("Run", false);
        }

        if (!Input.GetKey(KeyCode.D))
        {
            Anim.SetBool("HalfD", false);

        }

        //---------------------
        if (Input.GetKey(KeyCode.S) & !Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("Crou", true);
            Anim.SetBool("Walk", false);
            Anim.SetBool("Run", false);
        }

        if (!Input.GetKey(KeyCode.S))
        {
            Anim.SetBool("Crou", false);

        }



    }
}
