using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public Collider2D Hitbox;
    public Rigidbody2D rb;

    public float speed;

    private float radius = 0.5f;
    private EnemyManager gameManager;
    private bool donottriggeragainplease = false;
    private Vector3 moveDirection;


    private void Start()
    {
        gameManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        moveDirection = direction;

        rb.velocity = (new Vector2(moveDirection.x, moveDirection.y) * speed);
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

        float distanceToPlayer = (transform.position - player.transform.position).magnitude;

        if (Mathf.Abs(distanceToPlayer) < radius)
        {
            print("Game End");
            Application.Quit();
        }
    }



}
