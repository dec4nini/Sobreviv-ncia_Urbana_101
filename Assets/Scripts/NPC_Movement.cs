using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    public static NPC_Movement instance;
    public float decisionTimeCount = 0;
    public int randomDirection;
    public float movespeed;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private Animator anima;
    private string currentAnimation;
    public bool canMove = true;
    //awake are only called when all objects are initialized
    private void Awake()
    {
        instance = this;
        if (canMove == true) 
        {
            decisionTimeCount = Random.Range(4, 7);
            rb = GetComponent<Rigidbody2D>();
            anima = gameObject.GetComponent<Animator>();
            anima.Play(PLAYER_IDLE);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            anima.Play(PLAYER_IDLE);
        }
    }

    //Animation States
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYERWALK = "PlayerWalk";

    // Update is called once per frame
    void Update()
    {
        if (canMove == true) 
        {
            //Get inputs
            ProcessInputs();
            //Animate
            Animate();
            //Move
            Move();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * movespeed, rb.velocity.y);
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {

            FlipChar();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipChar();
        }
        else if (moveDirection != 0)
        {
            anima.Play(PLAYERWALK);
        }
        else
        {
            anima.Play(PLAYER_IDLE);
        }

    }

    private void ProcessInputs()
    {

        if (decisionTimeCount > 0)
        {
            decisionTimeCount -= Time.deltaTime;
        }
        else
        {
            if (moveDirection >= 0)
            {
                moveDirection = -1;
            }
            else
            {
                moveDirection = 1;
            }

            decisionTimeCount = 3;
        }
    }

    private void FlipChar()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

