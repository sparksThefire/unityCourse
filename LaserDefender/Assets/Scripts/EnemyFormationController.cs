using UnityEngine;
using System.Collections;

public class EnemyFormationController : MonoBehaviour {

    public float enemySpeed = 2f;
    public float spawnDelay = 0.5f;
    public GameObject enemyPrefab;
    public SceneBoundary sceneBoundary;

    public float width = 10f;
    public  float height = 2f;

    private float enemyPadding = .5f;

    private bool moveRight = false;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(gameObject.transform.position, new Vector3(width, height));
    }

	// Use this for initialization
	void Start () {
        SpawnEnemies();
    }
	
	// Update is called once per frame
	void Update () {
        Movement();

        if (AllMembersDead())
        {
            SpawnUntilFull();
            Debug.Log("Empty Formation.");
        }
    }

    private void Movement()
    {

        // If at right screen edge
        if (GetRightEdge() >= sceneBoundary.GetMaxX(enemyPadding))
        {
            moveRight = false;
        } // If at left screen edge
        else if (GetLeftEdge() <= sceneBoundary.GetMinX(enemyPadding))
        {
            moveRight = true;
        }

        Vector3 newPosition = transform.position;
        float movementSpeed = enemySpeed * Time.deltaTime;

        if (moveRight)
        {
            newPosition += Vector3.right * movementSpeed;
        }
        else
        {
            newPosition += Vector3.left * movementSpeed;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, sceneBoundary.GetMinX(enemyPadding), sceneBoundary.GetMaxX(enemyPadding));

        gameObject.transform.position = newPosition;
    }
    
    private bool AllMembersDead()
    {

        foreach(Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }

        return true;
    }

    private Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount <= 0)
            {
                return childPositionGameObject;
            }
        }

        return null;
    }

    private void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            CreateEnemy(freePosition);
        }
        if (NextFreePosition()) {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    private void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            CreateEnemy(child);
        }
    }

    private void CreateEnemy(Transform parent)
    {
        parent.GetComponent<Position>().SpawnUnit();
    }

    private float GetRightEdge()
    {
        return gameObject.transform.position.x + (width / 2 - enemyPadding);
    }

    private float GetLeftEdge()
    {
        return gameObject.transform.position.x - (width / 2 - enemyPadding);
    }
}
