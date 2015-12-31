using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour
{

    public int health = 1;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
