using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    
    public AudioSource audioSource;
    public AudioClip fireClip;
    public AudioClip hitClip;

    void Start()
    {
        GameEventsBehavior.Current.OnEnemyDestroyed += OnEnemyDestroyed;
    }

    public void Fire()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);        
        audioSource.PlayOneShot(fireClip);
    }

    private void OnEnemyDestroyed()
    {
        audioSource.PlayOneShot(hitClip);
    }
}
