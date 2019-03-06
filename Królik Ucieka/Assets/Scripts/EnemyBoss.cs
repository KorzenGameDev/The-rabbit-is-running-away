using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    int damage = 100;
    float speed = 0;
    float maxDistance = 27f;

    Rigidbody2D rb;
    GameObject target;
    Player player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<GameMenager>().player;
        player = target.GetComponent<Player>();
        speed = player.GetSpeed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player!=null)
        {
            player.TakeDamage(damage);
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(gameObject.transform.position.x - target.transform.position.x) <= maxDistance)
        {
            rb.velocity = Vector2.right * speed * Time.deltaTime;
            player.canFast = true;
        }
        else if ((Mathf.Abs(gameObject.transform.position.x - target.transform.position.x) > maxDistance))
        {
            rb.velocity = Vector2.right * speed * Time.deltaTime;
            player.canFast = false;
        }
    }
}
