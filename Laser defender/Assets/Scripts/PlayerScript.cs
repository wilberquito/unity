using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {

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
        transform.position = new Vector2(transform.position.x + deltaX, transform.position.y + deltaY);
    }
}
