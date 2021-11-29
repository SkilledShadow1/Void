using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] SceneChanger sc;
    [SerializeField] GameObject gm;
    public int health = 100;
    public int damage = 20;
    private float timer =  0f;
    private float invincibilityLength = 1.2f;
    [SerializeField] bool playerWasHit;
    public Color damageColor = Color.red;
    public Color defaultColor;
    public Image damageImage;
    public float lerpTime;
    private float elapsedTime;


    private float EaseValue(float x) 
    {
        if (x < 0.5f)
            return 4 * x * x * x;
        else
        {
            return 1 - (Mathf.Pow((-2 * x) + 2, 3) / 2);
        }
    }

    bool returnToNormal;
    private void Update()
    {
        
        if (playerWasHit)
        {
            damageImage.color = Color.Lerp(damageImage.color, damageColor, EaseValue(elapsedTime / invincibilityLength));
            elapsedTime += Time.deltaTime;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                playerWasHit = false;
                returnToNormal = true;
                elapsedTime = 0;
            }
        }

        if (!playerWasHit && returnToNormal)
        {
            elapsedTime += Time.deltaTime;
            damageImage.color = Color.Lerp(damageImage.color, defaultColor, EaseValue(elapsedTime / 0.1f));

            if (elapsedTime >= 0.1f)
                returnToNormal = false;
        }

    }

    private void Damaged() 
    {
        
        if(elapsedTime < lerpTime) 
        {
            
        }
        elapsedTime += Time.deltaTime;
        elapsedTime = 0f;

        while(elapsedTime < lerpTime) 
        {
            damageImage.color = Color.Lerp(defaultColor, damageColor, elapsedTime / lerpTime);
            elapsedTime += Time.deltaTime;
        }

    }

    private void Start()
    {
        timer = invincibilityLength;
        sc = gm.GetComponent<SceneChanger>();
        float elapsedTime = 0f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.tag == "Enemy" && playerWasHit == false) 
        {
            health -= damage;
            if(health <= 0) 
            {
                sc.GameOver();
            }
            playerWasHit = true;
            timer = invincibilityLength;
            Damaged();

        }
    }
}
