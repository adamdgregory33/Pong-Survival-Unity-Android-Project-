using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    Rigidbody2D rb;
    public float bounceForce;
    public bool notStarted = true;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (notStarted) { 
            if (Input.anyKeyDown)
            {
                StartBounce();
                notStarted = false;
                GameManager.instance.GameStart();

            }
        }

    }


    void StartBounce()
    {
        float xDirection = Random.Range((float)-.5, (float).5);
        float yDirection = 1 - xDirection;
        Vector2 randomDirection = new Vector2(xDirection, yDirection);
        rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
        notStarted = false;
        
    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FallCheck")
        {
            GameManager.instance.Restart();
        }
        else if(collision.gameObject.tag == "Paddle")
        {
            GameManager.instance.ScoreUp();
            rb.velocity = rb.velocity * (100+GameManager.instance.score)/100;

            
        }
    }
}
