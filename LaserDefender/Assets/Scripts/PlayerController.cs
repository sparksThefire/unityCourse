using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float fireRate = 0.3f;
    public float speed = 7f;
    public float projectileSpeed = 2f;
    public GameObject projectile;
    public SceneBoundary sceneBoundary;

    private float padding = 0.1f;
    

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missle = collider.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            Debug.Log("Player hit.");
        }
    }

    public void Update () {
        Control();
    }

    public void Control()
    {
        // Movement
        Vector3 newPosition = gameObject.transform.position;
        float movementSpeed = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            newPosition += Vector3.left * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            newPosition += Vector3.right * movementSpeed;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, sceneBoundary.GetMinX(padding), sceneBoundary.GetMaxX(padding));
        gameObject.transform.position = newPosition;

        // Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, fireRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
    }

    public void Fire()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        GameObject lazer = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        lazer.transform.position += offset;
        lazer.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
    }
}
