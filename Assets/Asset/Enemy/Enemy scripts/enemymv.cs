using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bot : MonoBehaviour
{
    public float startWaitTime;
    private Animator anim;
    public float waitTime;
    private bool facingRight = true;
    public float speed = 3f;
    private Vector2 moveVector;
    public SpriteRenderer sr;
    public Transform[] moveSpots;
    private int randomspot;
    void Start()
    {
        randomspot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
    }
    void Update()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomspot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randomspot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomspot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            Flip();
        }
    }
    void Flip()
    {
        if (moveVector.x > 0 && facingRight == false)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (moveVector.x < 0 && facingRight == true)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}

