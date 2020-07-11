using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            if(touchPos.x < 0)
            {
                //move left if negative
                rb.velocity = Vector2.left * moveSpeed;
                

            }
            else
            {
                //move right if positive
                rb.velocity = Vector2.right * moveSpeed;


            }

        }
        else
        {

            rb.velocity = Vector2.zero;

        }
    }

    private void FixedUpdate()
    {
        TouchMove();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
