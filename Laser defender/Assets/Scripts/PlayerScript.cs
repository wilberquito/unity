using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //serialized variables
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] GameObject lasser;
    [SerializeField] float projectileSpeed = 10f;


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
        minX = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        minY = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEngine();
        Fire();
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var laser = Instantiate(lasser, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        }
    }

    void MoveEngine()
    {
        // to make delta x independent from velocity of frames per second
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        // to make delta x independent from velocity of frames per second
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        if (deltaX != 0)
        {
            var x = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
            transform.position = new Vector2(x, transform.position.y);

        }
        if (deltaY != 0)
        {
            var y = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
            transform.position = new Vector2(transform.position.x, y);

        }

        // logic to horizontal movement
    }
}
