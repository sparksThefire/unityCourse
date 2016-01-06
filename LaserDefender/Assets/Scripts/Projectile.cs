using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float rotation = 0f;
    public float damage = 100f;
    public bool playerProjectile = false;

    private float projectileSpeed = -2f;

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
        if (rotation != 0f)
        {
            GetComponent<Rigidbody2D>().rotation += rotation;
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

}
