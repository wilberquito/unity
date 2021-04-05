using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallComponent : MonoBehaviour
{
    // paremetro
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVel = 2f;
    [SerializeField] float yVel = 10f;


    // stado
    Vector2 startDistanceToPaddle;

    bool ballThrown = false;


    // Start is called before the first frame update
    void Start()
    {
        startDistanceToPaddle = transform.position - paddle1.transform.position;
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVel, yVel);
            ballThrown = true;
        }
    }


    private void LockBallToPaddle()
    {
        Vector2 paddle1Pos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddle1Pos + startDistanceToPaddle;
    }
}
