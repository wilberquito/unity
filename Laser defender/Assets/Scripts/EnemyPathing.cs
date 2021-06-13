using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;

    //float movementSpeed = 2f;
    List<Transform> waypoints = new List<Transform>();
    int visitedPoints = 0;

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        if (waveConfig)
        {
            if (visitedPoints < waveConfig.GetWayPoints().Count)
            {
                var step = Time.deltaTime * waveConfig.GetSpawnMovementSpeed(); ;
                var currentPos = transform.position;
                var nextPos = waveConfig.GetWayPoints()[visitedPoints].transform.position;

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
}
