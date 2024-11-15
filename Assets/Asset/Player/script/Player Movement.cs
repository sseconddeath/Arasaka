using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public Vector2 moveVector;
    public float speed;
    private Animator anim;

    private FootstepController footstepController;

    private void Awake()
    {
        footstepController = GetComponentInChildren<FootstepController>(); // Get the FootstepController component
    }

    void Start()
    {
        
    }

    void Update()
    {
        anim = GetComponent<Animator>();
        walk();
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.y = Input.GetAxis("Vertical") * speed;
        //anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        player.velocity = new Vector2(moveVector.x, moveVector.y);
        if (moveVector.x != 0)
        {
            footstepController.StartWalking(); // Start playing footsteps if moving
        }
        else
        {
            footstepController.StopWalking(); // Stop playing footsteps if not moving
        }

        if (moveVector.y != 0)
        {
            footstepController.StartWalking(); // Start playing footsteps if moving
        }
        else
        {
            footstepController.StopWalking(); // Stop playing footsteps if not moving
        }
    }
}
