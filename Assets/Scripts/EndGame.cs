using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] SceneChanger sc;
    [SerializeField] GameObject gm;

    private void Start()
    {
        sc = gm.GetComponent<SceneChanger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sc.Win();
        }
    }
}
