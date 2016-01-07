using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public float shotsPerSecond = 0.5f;
    public GameObject projectile;
    public AudioClip lazerSound;
    public AudioClip deathSound;

    private ScoreKeeper scoreKeeper;
    private float health = 100f;

    private int scoreValue = 1;

    public void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

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
                scoreKeeper.Score(scoreValue);
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
                Destroy(gameObject);
            }
        }
    }

    private void Fire()
    {
        Debug.Log(string.Format("{0} is trying to fire", gameObject.name));
        foreach (Transform weaponMount in transform)
        {
            Instantiate(projectile, weaponMount.transform.position, Quaternion.identity);
        }
        AudioSource.PlayClipAtPoint(lazerSound, transform.position);
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
}
