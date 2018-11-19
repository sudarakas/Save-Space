﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [Header("Player Movement")]
    [SerializeField]
    float moveSpeed = 10f;
    [SerializeField]
    float padding = 1f;
    [SerializeField]
    int health = 300;
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

    [Header("Projectile")]
    [SerializeField]
    GameObject laserPrefab;
    [SerializeField]
    float projectileSpeed = 10f;
    [SerializeField] float projectileFirePeriod = 0.1f;
    Coroutine fireCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

	// Use this for initialization
	void Start () {
        SetUpMoveBoundaries();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Fire();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage damageDealer = other.gameObject.GetComponent<Damage>();
        if (!damageDealer) {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(Damage damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die() {
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);

    }

    public int getHealth() {
        return health;
    }

    private void Fire(){
        if (Input.GetButtonDown("Fire1"))
        {
            fireCoroutine = StartCoroutine(FireContinuous());
        }
        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator FireContinuous() {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, shootSFXVolume);
            yield return new WaitForSeconds(projectileFirePeriod);
        }
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    private void Move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin,xMax);

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);


        transform.position = new Vector2(newXPos,newYPos); 
    }

}
