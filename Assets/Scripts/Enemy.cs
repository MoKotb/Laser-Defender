using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField]
    int health = 100;
    [SerializeField]
    int score = 150;

    [Header("Shooting")]
    [SerializeField]
    float minTimeBetweenShot = 0.2f;
    [SerializeField]
    float maxTimeBetweenShot = 3f;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float projectileSpeed = 10f;

    [Header("Sound")]
    [SerializeField]
    AudioClip DestorySound;
    [SerializeField] [Range(0,1)]
    float DestorySoundVolume = 0.75f;
    [SerializeField]
    AudioClip ShootingSound;
    [SerializeField]
    [Range(0, 1)]
    float ShootingSoundVolume = 0.75f;

    [Header("Explosion")]
    [SerializeField]
    GameObject DestoryVFX;
    [SerializeField]
    float DurationOfExplosion = 1f;
    
    private float shotCounter;

    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShot,maxTimeBetweenShot);
    }

    void Update()
    {
        CountDownAndShot();
    }

    private void CountDownAndShot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShot, maxTimeBetweenShot);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(projectile,transform.position,Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(ShootingSound, Camera.main.transform.position, ShootingSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject explosion = Instantiate(DestoryVFX,transform.position,transform.rotation);
        Destroy(explosion, DurationOfExplosion);
        FindObjectOfType<GameSession>().SetScore(score);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(DestorySound, Camera.main.transform.position, DestorySoundVolume);
    }
}
