using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public float offset = 0.5f;
    public float bombDelay = 1f;
    public int numberOfProjectiles = 8;
    public float projectileSpeed = 2f;
    public GameObject projectile;

    // Use this for initialization
    public void Start()
    {
        Debug.Log("Bomb Instantiated");
        Invoke("Explode", bombDelay + Random.Range(0f, 1f));
    }

    public void SetNumOfProjectiles(int projectilesNumber)
    {
        numberOfProjectiles = projectilesNumber;
    }

    public void Explode()
    {
        Debug.Log("Bomb Explode");
        float degreeDifference = (2f * Mathf.PI) / numberOfProjectiles;
        
        for (int i = 0; i <= numberOfProjectiles; i++)
        {
            float currentDegree = (i) * degreeDifference;
            Vector2 unitCircle = UnitCircle(currentDegree);
            Vector3 projectilePosition = unitCircle;
            projectilePosition.y *= offset;
            projectilePosition.x *= offset;
            
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.transform.position = transform.position + projectilePosition;
            bullet.GetComponent<Rigidbody2D>().velocity = transform.GetComponent<Rigidbody2D>().velocity;
            bullet.GetComponent<Projectile>().SetAcceleration(unitCircle);
        }
    }

    private Vector2 UnitCircle(float currentDegree)
    {
        float xVelocity = Mathf.Cos(currentDegree);
        float yVelocity = Mathf.Sin(currentDegree);

        return new Vector2(xVelocity, yVelocity);
    }
}