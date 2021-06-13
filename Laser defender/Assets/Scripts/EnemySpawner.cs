using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> wavesConfig;
    [SerializeField] bool loop = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do {
            yield return StartCoroutine(SpawnWaves());
        } while(loop);
    }

    private IEnumerator SpawnWaves()
    {
        foreach (var wave in wavesConfig)
        {
            yield return StartCoroutine(SpawnWave(wave));
        }
    }

    private IEnumerator SpawnWave(WaveConfig wave)
    {

        for (int i = 0; i < wave.GetWaveLength(); i++)
        {
            var timeGap = wave.GetTimeGap();
            var startPosition = wave.GetWayPoints()[0].transform.position;
            var instance = Instantiate(wave.GetPrefab(), startPosition, Quaternion.identity);

            instance.GetComponent<EnemyPathing>().SetWaveConfig(wave);
            yield return new WaitForSeconds(timeGap);
        }
    }

}
