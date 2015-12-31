using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float shotsPerSecond = 0.5f;
    public float projectileSpeed = 2f;
    public GameObject projectile;

    private float health = 100f;

    public void Update()
    {
        float probability = shotsPerSecond * Time.deltaTime;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missle = collider.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            health -= missle.GetDamage();
            missle.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Fire()
    {
        Vector3 offset = new Vector3(0, -1, 0);
        GameObject lazer = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        lazer.transform.position += offset;
        lazer.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1f * projectileSpeed);
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
}
