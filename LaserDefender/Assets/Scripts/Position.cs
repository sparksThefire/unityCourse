using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour
{

    public int health = 1;
    public GameObject enemyPrefab;

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    public void SpawnUnit()
    {
        GameObject enemy = Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
        enemy.transform.parent = gameObject.transform;
        enemy.GetComponent<EnemyController>().SetHealth(health);
    }
}
