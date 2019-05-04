using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Wave",menuName = "ScriptableObjects/WaveConfig",order =0)]
public class WaveConfig : ScriptableObject
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject pathPrefab;
    [SerializeField]
    float moveSpeed = 2f;
    [SerializeField]
    float timeBetweenSpawns = 0.5f;
    [SerializeField]
    int numberOfEnemies = 5;
    
    public GameObject GetEnemy()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
}
