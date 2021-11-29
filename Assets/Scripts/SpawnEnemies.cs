using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> spawnPoints = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        { 
            for(int i = 0; i < spawnPoints.Count; i++) 
            {
                Enemy e = Instantiate(enemy, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
                e.Target = player;
            }

            Destroy(this.gameObject);
        }

        
    }
}
