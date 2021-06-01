using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //serialized variables
    [SerializeField] float moveSpeed = 10f;

    // class variables
    float minX, maxX;
    float minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        SetEdges();
    }

    void SetEdges()
    {
        var camera = Camera.main;
        minX = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        minY = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEngine();
    }

    void MoveEngine()
    {
        // to make delta x independent from velocity of frames per second
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        // to make delta x independent from velocity of frames per second
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // logic to horizontal movement
        if (transform.position.x > minX && transform.position.x < maxX)
        {
            transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);
        }
        else if (transform.position.x < minX && deltaX > 0)
        {
            transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);
        }
        else if (transform.position.x > maxX && deltaX < 0)
        {
            transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);
        }

        // logic to vertical movement
        if (transform.position.y > minY && transform.position.y < maxY)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + deltaY);
        }
        else if (transform.position.y < minY && deltaY > 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + deltaY);
        }
        else if (transform.position.y > maxY && deltaY < 0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + deltaY);
        }
    }
}
