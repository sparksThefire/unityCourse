using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float maxPlayerHp = 500f;
    public float fireRate = 0.3f;
    public float shieldRate = 2f;
    public float speed = 7f;
    public float projectileSpeed = 2f;
    public GameObject projectile;
    public GameObject shield;
    public SceneBoundary sceneBoundary;
    public AudioClip lazerSound;

    private float currentPlayerHp;
    private float shieldCooldown = 0f;
    private float fireCooldown = 0f;
    private float padding = 0.1f;
    private Text playerHpText;
    private Slider playerHpBar;

    public void Start()
    {
        playerHpText = GameObject.Find("PlayerHp").GetComponent<Text>();
        playerHpBar = GameObject.Find("PlayerHealthBar").GetComponent<Slider>();
        currentPlayerHp = maxPlayerHp;
        playerHpBar.maxValue = maxPlayerHp;
        UpdateHpUI();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missle = collider.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            Debug.Log("Player hit.");
            Hit(missle.GetDamage());
            missle.Hit();
        }
    }

    public void Update () {
        Control();
    }

    public void Hit(float damage)
    {
        currentPlayerHp -= damage;
        if (currentPlayerHp <= 0f)
        {
            Die();
        }
        UpdateHpUI();
    }

    public void Die()
    {
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>() as LevelManager;
        man.LoadLevel("End Screen");
        Destroy(gameObject);
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

        float currentTime = Time.time;
        bool hasShield = false;

        // Shield
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Shield>())
            {
                hasShield = true;
            }
        }

        if (currentTime >= shieldCooldown && !hasShield)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                GameObject summonedShield = Instantiate(shield, transform.position, Quaternion.identity) as GameObject;
                summonedShield.transform.parent = gameObject.transform;
            }
        }

        // Fire
        if (currentTime >= fireCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                InvokeRepeating("Fire", 0.000001f, fireRate);
                fireCooldown = currentTime + fireRate;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            CancelInvoke("Fire");
        }
    }

    public void ShieldDestroyed()
    {
        shieldCooldown = Time.time + shieldRate;
    }

    public void Fire()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        GameObject lazer = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        lazer.transform.position += offset;
        lazer.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(lazerSound, transform.position);
    }

    public void UpdateHpUI()
    {
        playerHpBar.value = currentPlayerHp;
    }
}
