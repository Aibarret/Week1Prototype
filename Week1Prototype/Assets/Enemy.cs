using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Collider2D Hitbox;
    private EnemyManager gameManager;
    private bool donottriggeragainplease = false;

    private void Start()
    {
        gameManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MobUnit" && !donottriggeragainplease)
        {
            donottriggeragainplease = true;
            print("Collide");
            gameManager.spawn();
            Destroy(gameObject);

        }
    }



}
