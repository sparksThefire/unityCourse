using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    private float shieldHP = 100;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile missle = collider.gameObject.GetComponent<Projectile>();
        if (missle)
        {
            Hit(missle.damage);
            missle.Hit();
        }
    }

    public void Hit(float damage)
    {
        shieldHP -= damage;
        if (shieldHP <= 0f)
        {
            transform.parent.GetComponent<PlayerController>().ShieldDestroyed();
            Destroy(gameObject);
        }
    }
}
