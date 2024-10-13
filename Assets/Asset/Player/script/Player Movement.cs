using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public Vector2 moveVector;
    public float speed;



    void Start()
    {
        
    }

    void Update()
    {
        walk();
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.y = Input.GetAxis("Vertical") * speed;
        //anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        player.velocity = new Vector2(moveVector.x, moveVector.y);
    }
}
