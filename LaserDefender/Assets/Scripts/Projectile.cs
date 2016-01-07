using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float rotation = 0f;
    public float damage = 100f;
    public bool playerProjectile = false;
    public Vector2 acceleration = new Vector2(0,0);

    private float projectileSpeed = -2f;
    private float lowestYVelocity = -1f;

    public void Start()
    {
        if (playerProjectile)
        {
            projectileSpeed *= -1;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
    }

    public void Update()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

        if (rotation != 0f)
        {
            rigidBody.rotation += rotation;
        }

        if (rigidBody.velocity.y < lowestYVelocity)
        {
            rigidBody.velocity += acceleration;
        }
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void SetAcceleration(Vector2 accel)
    {
        accel *= 0.0075f;
        acceleration = accel;
    }

}
