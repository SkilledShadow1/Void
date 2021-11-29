using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunScript : MonoBehaviour
{

    [SerializeField] GameObject player;

    [SerializeField] GameObject bulletSpawn;

    bool pressingShoot;

    bool justShot;

    public float time = 0f;

    [SerializeField] float fireRate = 0.25f;

    [SerializeField] LayerMask enemyLayer;


    private void Start()
    {

    }

    void Update()
    {
        faceMouse();
        Shoot();
        Reload();
        InputShoot();
    }

    void Reload() 
    {
        if (justShot)
        {
            time += Time.deltaTime;
            if(time > fireRate) 
            {
                justShot = false;
                
            }
        }
    }

    private void faceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2
        (
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );

        transform.right = direction;
    }


    private void InputShoot() 
    {
        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            pressingShoot = true;
            Debug.Log("Shooting");
        }
        else 
        {
            pressingShoot = false;
        }
    }


    private void Shoot()
    {
        if (pressingShoot && justShot == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(bulletSpawn.transform.position, bulletSpawn.transform.right, Mathf.Infinity);
            time = 0;

            if (hit.collider != null && hit.collider.tag == "Enemy") 
            {
                Debug.LogError("Yes");
                EnemyHealth em = hit.collider.gameObject.GetComponent<EnemyHealth>();
                em.enemyHeath -= em.enemyDamage;
            }

            justShot = true;
        }


    }
}
