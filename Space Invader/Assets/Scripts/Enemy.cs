using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Configuration variables
    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float minTimeBetweenShots = 0.3f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    float shotCounter;
    [Header("Player")]
    [SerializeField] float health = 100f;
    [SerializeField] int killPoints = 100;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathClip;
    [SerializeField] float deathClipVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeEnemyFire());
    }

    private IEnumerator MakeEnemyFire()
    {
        while (gameObject)
        {
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
            yield return new WaitForSeconds(shotCounter);
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            ProcessHit(damageDealer);
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0f)
        {
            Die();
        }
        damageDealer.Hit();
    }

    private void Die()
    {
        GameObject destroyedVFX = Instantiate(deathVFX, gameObject.transform.position, Quaternion.identity) as GameObject;
        FindObjectOfType<GameSession>().IncrementCurrentScore(killPoints);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, deathClipVolume);
    }
}
