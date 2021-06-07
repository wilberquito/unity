using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject path;
    [SerializeField] float spawnGap = 0.5f;
    [SerializeField] float spawnFactor = 0.3f;
    [SerializeField] int waveLength = 5;


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
    public float GetSpawnGap() { return spawnGap; }
    public float GetSpawnFactor() { return spawnFactor; }
    public int GetWaveLength() { return waveLength; }

}
