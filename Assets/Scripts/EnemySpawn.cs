using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [SerializeField]
    List<WaveConfig> waveConfigs;
    [SerializeField] int startWave = 0;
    [SerializeField]
    bool looping = false;



	// Use this for initialization
	IEnumerator Start() {

        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
	}

    private IEnumerator SpawnAllWaves() {
        for (int waveIndex = startWave; waveIndex < waveConfigs.Count; waveIndex++) {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) {

        for (int enemyCount = 0; enemyCount < waveConfig.getNumberOfEnemies(); enemyCount++) {
            
            var newEnemy = Instantiate(waveConfig.getEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<enemyPath>().SetWaveConfig(waveConfig); 
            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawns());

        }
        
    }
}
