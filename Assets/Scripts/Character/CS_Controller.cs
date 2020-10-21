using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using System.Linq;

public class CS_Controller : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerBody;
    private Vector3 gravitySpeed;

    [SerializeField] int movingInt;

    public float jumpSpeed = 2000f;
    public float fallSpeed = -100f;

    private int doubleJump = 0;
    private bool noJumpAllowed = false;
    private bool doubleJumpExtraPower = false;

    GameObject go_Collider;

    Transform DustSpawner;
    ParticleSystem psDust;

    Animator anim;

    public GameObject dustParticleEffect;


    private void Start()
    {
        anim = gameObject.transform.Find("Cool Dino Scaler").gameObject.transform.Find("Cool Dino").GetComponentInChildren<Animator>();
    }

    void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
        gravitySpeed = new Vector3(0, -fallSpeed, 0);
        go_Collider = GameObject.Find("Collider");

        psDust = gameObject.transform.Find("Dust Spawner").gameObject.transform.Find("Dust").GetComponentInChildren<ParticleSystem>();
        psDust.Play();
    }

    void Update ()
    {
        //Debug.Log(doubleJump);
        //Debug.Log("Animation_Condition"); 

        if (playerBody.velocity.y < -2) //AB controls speed going up and coming back down with drag on players rigidbody
        {
            playerBody.drag = 0;
        } else if (playerBody.velocity.y < 8)
        {

            playerBody.drag = 1;
        }


    }

    private void OnTriggerEnter(Collider col) //AB trigger events 
    {
        switch (col.tag)
        {
            case "Jump Collider": doubleJump = 0; noJumpAllowed = false; playerBody.drag = 0; anim.SetInteger("Animation_Condition", 0); psDust.Play(); doubleJumpExtraPower = false;  break;
            case "Dust Collider": psDust.Stop(); break;

                
                //case "Drag Collider": playerBody.drag = 5; doubleJumpExtraPower = true; break;

        }
    }


    /* void OnCollisionEnter(Collision col) //collision events
     {
         switch (col.gameObject.tag)
         {


         }
     }*/


private void OnGUI()
    {
        if (noJumpAllowed == false) //AB checks if player can jump again
        {
            if (GUI.Button(new Rect(10, 10, 150, 100), "Jump")) //AB creates button to jump with
            {

                playerBody.AddForce(new Vector3(0f, jumpSpeed, 0f), ForceMode.Impulse);

                anim.SetInteger("Animation_Condition", 1);

                doubleJump++; //adds to double jump counter

                  if (doubleJumpExtraPower == true) //can he use 
                 {
                     playerBody.AddForce(new Vector3(0f, jumpSpeed + 50, 0f), ForceMode.Impulse); // adds power to double jump
                    doubleJumpExtraPower = false;

                 }
               
                

                if (doubleJump >= 2)
                {
                    noJumpAllowed = true;
                }
                else noJumpAllowed = false;


            }
            else
            {
                Physics.gravity = gravitySpeed;

            }
        }
    }
}