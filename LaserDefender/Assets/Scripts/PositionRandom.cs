using UnityEngine;
using System.Collections;

public class PositionRandom : MonoBehaviour
{

    public int health = 1;
    public GameObject[] enemyPrefab;

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    public void SpawnUnit()
    {
        int randomUnitNumber = Random.Range(0, enemyPrefab.Length);
        GameObject enemy = Instantiate(enemyPrefab[randomUnitNumber], gameObject.transform.position, Quaternion.identity) as GameObject;
        enemy.transform.parent = gameObject.transform;
        enemy.GetComponent<EnemyController>();
    }
}
