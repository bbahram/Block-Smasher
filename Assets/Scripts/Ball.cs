using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] PaddleMove paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    Vector2 paddleAndBall;
    bool check = true;
    //cashed component refrence
    AudioSource myAudio;
    Rigidbody2D myRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        paddleAndBall = transform.position - paddle1.transform.position;
        myAudio = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }


    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            check = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleAndBall + paddlePos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak=new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (!check)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            //GetComponent<AudioSource>().PlayOneShot(clip);
            myAudio.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}
