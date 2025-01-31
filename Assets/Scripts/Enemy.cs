﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    float health = 100;
    [SerializeField]
    int scoreVal = 200;
    [SerializeField]
    float shotCounter;
    [SerializeField]
    float minTimeBetweenShots = 0.2f;
    [SerializeField]
    float maxTimeBetweenShots = 3f;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float projectileSpeed = 10f;
    [SerializeField]
    GameObject deathVFX;
    [SerializeField]
    float explotionDuration = 1f;
    [SerializeField]
    AudioClip deathSFX;
    [SerializeField]
    [Range(0, 1)]
    float deathSFXVolume = 0.7f;
    [SerializeField]
    AudioClip shootSFX;
    [SerializeField]
    [Range(0, 1)]
    float shootSFXVolume = 0.2f;



	// Use this for initialization
	void Start () {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
	}
	
	// Update is called once per frame
	void Update () {
        CountDownAndShoot();
	}

    private void CountDownAndShoot() {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f) {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire() {
        GameObject laser = Instantiate(projectile,transform.position,Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootSFXVolume);
   }

    private void OnTriggerEnter2D(Collider2D other) {
        Damage damageDealer = other.gameObject.GetComponent<Damage>();
        if (!damageDealer)
        {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void Die() {
        FindObjectOfType<Sessions>().addToScore(scoreVal);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, explotionDuration);
        AudioSource.PlayClipAtPoint(deathSFX,Camera.main.transform.position,deathSFXVolume);
    }

    private void ProcessHit(Damage damageDealer) {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }
}
