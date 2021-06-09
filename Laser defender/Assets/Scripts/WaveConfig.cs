using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject path;
    [SerializeField] float timeGap = 0.5f;
    [SerializeField] float spawnFactor = 0.3f;
    [SerializeField] int waveLength = 5;
    [SerializeField] float spawnMovementSpeed = 2f;


    public GameObject GetPrefab() { return prefab; }
    
    public List<Transform> GetWayPoints()
    {
        List<Transform> ls = new List<Transform>();

        foreach (Transform child in path.transform)
        {
            ls.Add(child);
        }

        return ls;
    }
    public float GetTimeGap() { return timeGap; }
    public float GetSpawnFactor() { return spawnFactor; }
    public int GetWaveLength() { return waveLength; }
    public float GetSpawnMovementSpeed() { return spawnMovementSpeed; }

}
