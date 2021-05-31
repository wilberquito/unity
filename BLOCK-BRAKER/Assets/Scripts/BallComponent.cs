using System.Collections.Generic;
using UnityEngine;

public class BallComponent : MonoBehaviour
{
    // paremetro
    [SerializeField] Paddle paddle;
    [SerializeField] float xVel = 0f;
    [SerializeField] float yVel = 10f;

    [SerializeField] AudioClip[] ballAudios;


    // stado
    Vector2 startDistanceToPaddle;

    bool ballThrown = false;

    // referencia al componente de audio
    AudioSource audioSource;
    Rigidbody2D rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        startDistanceToPaddle = transform.position - paddle.transform.position;

        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!ballThrown)
        {
            ThrowBallOnMouseClick();
            LockBallToPaddle();
        }
    }

    private void ThrowBallOnMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            rigidBody.velocity = new Vector2(xVel, yVel);
            ballThrown = true;
        }
    }



    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + startDistanceToPaddle;
    }

    private void HandleBlockCollision()
    {
        List<int> randoms = new List<int>();

        float factor = Random.Range(0f, 0.2f);


        for (int i = 0; i < 2; i++)
        {
            randoms.Add(Random.Range(0, 2));
        }

        for (int i = 0; i < randoms.Count; i++)
        {
            switch (i)
            {
                case 0: //
                    if (randoms[i] == 0)
                    {
                        Vector2 v = new Vector2(factor * 1f, 0f);
                        rigidBody.velocity += v;
                    }
                    else
                    {
                        Vector2 v = new Vector2(factor * -1f, 0f);
                        rigidBody.velocity += v;
                    }
                    break;
                case 1:
                    if (randoms[i] == 0)
                    {
                        Vector2 v = new Vector2(0f, factor * 0.5f);
                        rigidBody.velocity += v;
                    }
                    else
                    {
                        Vector2 v = new Vector2(0f, factor * -0.5f);
                        rigidBody.velocity += v;
                    }
                    break;
            }
        }
    }

    private void HandlePaddleCollision()
    {

        float factor = Random.Range(0f, 0.8f);
        Vector2 vy = new Vector2(0, 1 * factor);
        rigidBody.velocity += vy;


        if (Random.Range(0, 2) == 1)
        {
            Vector2 vx = new Vector2(1 * (factor / 2),0);
            rigidBody.velocity += vx;
        }
        else
        {
            Vector2 vx = new Vector2(-1 * (factor / 2), 0);
            rigidBody.velocity += vx;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (ballThrown)
        {
            AudioClip clip = ballAudios[Random.Range(0, ballAudios.Length)];
            audioSource.PlayOneShot(clip);

            // paddle collision
            if (collision.gameObject == paddle.gameObject)
            {
                HandlePaddleCollision();
            }
            else // block collision
            {
                //HandleBlockCollision();
            }
        }
    }
}
