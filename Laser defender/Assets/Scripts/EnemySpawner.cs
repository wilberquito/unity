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

        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        foreach (var wave in wavesConfig)
        {
            StartCoroutine(SpawnWave(wave));
            yield return new WaitForSeconds(1f);
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
