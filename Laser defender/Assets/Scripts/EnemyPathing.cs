using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;

    float movementSpeed = 2f;
    List<Transform> waypoints = new List<Transform>();
    int visitedPoints = 0;

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (this.waveConfig == null)
        {
            throw new System.Exception("Wave config not defined");
        }
        else
        {
            movementSpeed = waveConfig.GetSpawnMovementSpeed();
            waypoints = waveConfig.GetWayPoints();
            //setteo la posicion incial
            transform.position = waypoints[visitedPoints].transform.position;
            visitedPoints++;
        }
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
            var step = Time.deltaTime * movementSpeed;
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
