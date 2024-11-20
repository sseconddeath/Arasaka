using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public Vector2 moveVector;
    public float speed;
    private Animator anim;
    public bool faceRight = true;
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
        Reflect();
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.y = Input.GetAxis("Vertical") * speed;
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        player.velocity = new Vector2(moveVector.x, moveVector.y);
    }

    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }
}
