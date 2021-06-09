using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> wavesConfig;
    int currentWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        var currentWave = this.wavesConfig[this.currentWave];
        StartCoroutine(SpawnWave(currentWave));
    }

    private IEnumerator SpawnWave(WaveConfig wave)
    {

        for (int i = 0; i < wave.GetWaveLength(); i++)
        {
            var timeGap = wave.GetTimeGap();
            var startPosition = wave.GetWayPoints()[0].transform.position;

            yield return new WaitForSeconds(timeGap);
            
            Instantiate(wave.GetPrefab(), startPosition, Quaternion.identity);
        }
    }

}
