using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject pathPrefab;
    [SerializeField]
    float timeBetweenSpawns = 0.5f;
    [SerializeField]
    float spwanRandomFactor = 0.3f;
    [SerializeField]
    int numberOfEnemies = 5;
    [SerializeField]
    float moveSpeed = 2f;

    public GameObject getEnemyPrefab() 
    {
        return enemyPrefab;
    }

    public List<Transform> GetWayPoints()
    {
        var waveWayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform) {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }

    public float getTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float getSpwanRandomFactor()
    {
        return spwanRandomFactor;
    }

    public int getNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    
}
