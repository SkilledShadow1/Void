using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHeath = 100;

    public int enemyDamage = 20;
    
    // Update is called once per frame
    void Update()
    {
        if (enemyHeath < 0) 
        {
            Destroy(gameObject);
        }
    }
}
