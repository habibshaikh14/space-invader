using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Configuration variables
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float health = 100f;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.3f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeEnemyFire());
        // shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
        damageDealer.Hit();
    }
}
