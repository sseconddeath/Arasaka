using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 15f;
    float speed = 10f;
    private Vector2 moveVector;
    private Animator anim;
    public SpriteRenderer sr;
    private bool facingRight = true;
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;

    public float flyingTime = 0.65f;
    public float flyingSpeed = 7f;
    public float gravityScale = 1f;
    [SerializeField]
    private UnityEvent<float> FuelChagedPercent;

    private float _fuel;

    public float Fuel
    {
        get => _fuel;
        set
        {
            _fuel = value;
            FuelChagedPercent?.Invoke(_fuel / flyingTime);

            //if (_fuel <= 0)
            //{
               
            //}
        }
    }


    public AudioSource JumpAudio, StepsAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb.gravityScale = gravityScale;
        Fuel = flyingTime;
    }

    void Update()
    {
        anim = GetComponent<Animator>();
       
        Walk();
        //Jump();
        Flight();
        Flip();
        CheckingGround();
    }

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
        if (onGround) Fuel = flyingTime;
    }
    void Jump() //пока не используется
    {
        if (Input.GetKeyDown(KeyCode.Space)&& onGround)
        {
            rb.AddForce(Vector2.up * speed);
            JumpAudio.Play();
            rb.AddForce(Vector2.up * jumpForce);
        }

    }

    void Flight()
    {
        if (Input.GetKey(KeyCode.Space))
        {
                if (Fuel > 0)
                    rb.velocity = new Vector2(rb.velocity.x, flyingSpeed);
            Fuel -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fall();
        }
    }
    private void Fall()
    {
        rb.AddForce(Vector2.down * gravityScale);
    }

    void Walk()//ходьба
    {
        
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
    void Flip() //поворот персонажа
    {
        if ( moveVector.x > 0 && facingRight == false)
        {
            StepsAudio.Play();
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
            //sr.flipX = false;
        }
        else if( moveVector.x < 0 && facingRight == true)
        {
            StepsAudio.Play();
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
            //sr.flipX = true;
        }
    }
    //[System.Obsolete]
    //void LoadScene()
    //{
    //    Application.LoadLevel(Application.loadedLevel);

    //}
    //private void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (coll.tag == "enemy")
    //        gameObject.SetActive(false);
    //    Invoke("LoadScene", 1.5f);
    //    LoadScene();
    //}
}
