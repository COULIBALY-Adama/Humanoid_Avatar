using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

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
        // on va recuperer le composant du caractere controler
        Player = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //Pour la commaande avec la touche directionnelle du clavier
        // on va recupere les input Vertical et Horrizontal
        DirectionDeplacement.z = Input.GetAxisRaw("Vertical");
        DirectionDeplacement.x = Input.GetAxisRaw("Horizontal");
        DirectionDeplacement = transform.TransformDirection(DirectionDeplacement);

        // Deplacements
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Player.Move(DirectionDeplacement * Time.deltaTime * RunSpeed);
        }
        else
        {
            Player.Move(DirectionDeplacement * Time.deltaTime * Speed); 
        }

              
        transform.Rotate(0, Input.GetAxisRaw("Mouse X")*Sensi, 0); // Pour la rotation avec la souoris

        // Saut
        if(Input.GetKeyDown(KeyCode.Space)&& Player.isGrounded) // Space correspond au bouton de la souris
        {
            DirectionDeplacement.y = Jump;
            Anim.SetTrigger("jumping");
        }

        // Gravité
        if(!Player.isGrounded)
        {
            DirectionDeplacement.y -= gravite * Time.deltaTime;
        }

        //Animation
        if(Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("walk", true);
            Anim.SetBool("run", false);

        }
        if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("walk", false);
            Anim.SetBool("run", true);

        }

        if (!Input.GetKey(KeyCode.W))
        {
            Anim.SetBool("walk", false);
            Anim.SetBool("run", false);
        }
    }
}


   
        