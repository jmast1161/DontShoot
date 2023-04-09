using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public WeaponBehavior weaponBehavior;
    private Vector2 moveDirection;
    private Vector2 mousePosition;

    public AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameEventsBehavior.Current.GameOverShown)
        {
            var moveX = Input.GetAxisRaw("Horizontal");
            var moveY = Input.GetAxisRaw("Vertical");

            if(Input.GetMouseButtonDown(0))
            {
                weaponBehavior.Fire();
            }

            moveDirection = new Vector2(moveX, moveY).normalized;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        var aimDirection = mousePosition - rb.position;
        rb.rotation = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;              
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {   
        if (col.gameObject.name == "Enemy")
        {   
            Destroy(gameObject);
            // game over
        }
    }
}
