using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAllEnemies : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPoints = new List<GameObject>();
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject player;
    private void Start()
    {
        for(int i = 0; i < spawnPoints.Count; i++) 
        {
            Enemy e = Instantiate(enemy, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
            e.Target = player;
            
        }
    }
}
