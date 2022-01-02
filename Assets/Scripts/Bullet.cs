using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float maxDistance = 10;
    public int damage = 5;

    private Vector2 startPosition;
    private float conquareDistance = 0;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize()
    {
        startPosition = transform.position;
        rb.velocity = transform.up * speed;
    }

    private void Update()
    {
        conquareDistance = Vector2.Distance(transform.position, startPosition);
        if (conquareDistance > maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collider " + collision.name);

        var damagable = collision.GetComponent<Damageable>();
        if (damagable != null)
        {
            damagable.Hit(damage);
        }

        DisableObject();
    }
}
