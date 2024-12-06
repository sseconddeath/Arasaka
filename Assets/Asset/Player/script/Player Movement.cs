using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioClip stepSound; //звук шага
    private AudioSource audioSource;
    public Rigidbody2D player;
    public Vector2 moveVector;
    public float speed;
    private Animator anim;
    public bool faceRight = true;
    private FootstepController footstepController;
    //Задержка между шагами
    private float stepDelay = 0.9f; 
    private float lastStepTime;
    private bool isMoving = false;

    private void Awake()
    {
        footstepController = GetComponentInChildren<FootstepController>();
    }

    void Start()
    {
        //для шагов
        audioSource = GetComponent<AudioSource>();
        lastStepTime = Time.time; 
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

        //звук шага
        if (moveVector.magnitude > 0) 
        {
            if (!isMoving) 
            {
                isMoving = true; 
                lastStepTime = Time.time + stepDelay; 
            }

            if (Time.time >= lastStepTime)
            {
                audioSource.PlayOneShot(stepSound); 
                lastStepTime += stepDelay; 
            }
        }
        else
        {
            isMoving = false; 
        }
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
