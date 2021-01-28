using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    float m_HorizontalMovement;
    float m_VerticalMovement;
    Animator m_Animator;
    public float runSpeed = 20.0f;
    Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool("moving?", false);
        //body = GetComponent<Rigidbody2D>();

    }

    public float Speed = 5f;

    private void Update()
    {



        m_HorizontalMovement = Input.GetAxisRaw("Horizontal");
        //m_Animator.SetFloat("Ydirection", m_HorizontalMovement);

        m_VerticalMovement = Input.GetAxisRaw("Vertical");
        //m_Animator.SetFloat("Xdirection", m_VerticalMovement);
        

        var input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        Vector3 velocity = input.normalized * Speed;
        transform.position += velocity * Time.deltaTime;

    }


    void FixedUpdate()
    {

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        //responsavel pela animação horizontal
        if (m_HorizontalMovement > 0)
        {
            m_Animator.SetFloat("Ydirection", 1);
            m_Animator.SetFloat("Xdirection", 0);

            m_Animator.SetFloat("YLastD", 1);
            m_Animator.SetFloat("XLastD", 0);
        }
        else if (m_HorizontalMovement < 0)
        {
            m_Animator.SetFloat("Ydirection", -1);
            m_Animator.SetFloat("Xdirection", 0);

            m_Animator.SetFloat("YLastD", -1);
            m_Animator.SetFloat("XLastD", 0);
        }
        //responsavel pela animação vertical
        else if (m_VerticalMovement > 0)
        {
            m_Animator.SetFloat("Xdirection", 1);
            m_Animator.SetFloat("Ydirection", 0);

            m_Animator.SetFloat("XLastD", 1);
            m_Animator.SetFloat("YLastD", 0);
        }
        else if (m_VerticalMovement < 0)
        {
            m_Animator.SetFloat("Xdirection", -1);
            m_Animator.SetFloat("Ydirection", 0);

            m_Animator.SetFloat("XLastD", -1);
            m_Animator.SetFloat("YLastD", 0);

        }

        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        if (m_VerticalMovement != 0 || m_HorizontalMovement != 0)
        {
            m_Animator.SetBool("moving?", true);
        }
        else
        {
            m_Animator.SetBool("moving?", false);

        }

    }
}
