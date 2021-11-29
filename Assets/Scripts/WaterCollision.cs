using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    [SerializeField] GameObject sceneChanger;
    [SerializeField] SceneChanger sc;

    private void Start()
    {
        sc = sceneChanger.GetComponent<SceneChanger>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            sc.GameOver();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            sc.GameOver();
        }
        
    }
}
