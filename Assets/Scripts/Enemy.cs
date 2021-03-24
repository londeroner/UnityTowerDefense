using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float health = 100;

    public int reward = 20;

    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 5f);
        PlayerStats.Money += 20;
    }

    internal void Slow(float slowPower)
    {
        speed = startSpeed * (1f - slowPower);
    }
}
