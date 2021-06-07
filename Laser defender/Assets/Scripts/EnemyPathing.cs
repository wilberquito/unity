using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    [SerializeField] WaveConfig waveConfig;
    [SerializeField] float movementVelocity = 2f;

    List<Transform> waypoints;
    int visitedPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWayPoints();

        //setteo la posicion incial
        transform.position = waypoints[visitedPoints].transform.position;
        visitedPoints++;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (visitedPoints < waypoints.Count)
        {
            var step = Time.deltaTime * movementVelocity;
            var currentPos = transform.position;
            var nextPos = waypoints[visitedPoints].transform.position;

            transform.position = Vector2.MoveTowards(currentPos, nextPos, step);

            if (transform.position == nextPos)
            {
                visitedPoints++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
