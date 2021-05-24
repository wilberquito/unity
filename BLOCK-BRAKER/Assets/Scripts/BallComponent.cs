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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ballThrown)
        {
            AudioClip clip = ballAudios[Random.Range(0, ballAudios.Length)];
            audioSource.PlayOneShot(clip);

            float pvx = rigidBody.velocity.x;
            float pvy = rigidBody.velocity.y;
            if (Random.Range(0, 2) == 0)
            {
                Vector2 vx = new Vector2(1f, 1f);
                rigidBody.velocity += vx;
            }
            else
            {
                Vector2 vx = new Vector2(-1f, 1f);
                rigidBody.velocity += vx;
            }
        }
    }
}
