using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public CharacterController controller;
    public float speed;
    public float jumpHeight;
    public float gravity;

    float horizontalMove;
    float verticalMove;
    private Vector3 jump;
    private Vector3 move;
    private bool grounded;


    private Animator anim;
    public int pv;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = controller.isGrounded;
        //Debug.Log(grounded);
        if (grounded)
        {
            // player won't stay grounded without some downward velocity
            jump.y = -2;
        }

        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = Vector3.up * jumpHeight;
            //Debug.Log("jumpin" + jump);
        }
        // add the horizontal and forward/backwards movement in the direction of the player
        move = transform.right * horizontalMove + transform.forward * verticalMove;
        move *= speed;

        if (!grounded)
        {
            // apply gravity to jump vector when in the air
            jump.y += gravity * Time.deltaTime;
        }
        // add the jump vector for vertical movement
        move.y = jump.y;

        controller.Move(move * Time.deltaTime);


        if (!grounded)
        {
            // floating animation while the player is in the air
            pv = 2;
        }
        else if (move.x != 0 || move.z != 0)
        {
            // running animation while the player is moving
            // i might add an animation for when the player is moving backwards
            pv = 1;
        }
        else
        {
            // idle animation when the player isn't moving
            pv = 0;
        }
        anim.SetInteger("AnimationPar", pv);
    }
}
