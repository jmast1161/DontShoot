using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerBehavior player;
    private float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 localScale;

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        if (col.gameObject.name == "Bullet(Clone)")
        {   
            Destroy(gameObject);
            GameEventsBehavior.Current.EnemyDestroyed();
        }

        if(col.gameObject.name == "Player")
        {
            GameEventsBehavior.Current.GameOver();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(PlayerBehavior)) as PlayerBehavior;
        moveSpeed = 2f;
        localScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if(player != null)
        {
            directionToPlayer = (player.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
        }

        if(GameEventsBehavior.Current.GameOverShown)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
