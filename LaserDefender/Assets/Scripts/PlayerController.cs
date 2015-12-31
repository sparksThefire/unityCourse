using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 7f;
    public float padding = 0.5f;

    private float minXConstraint = -6;
    private float maxXConstraint = 6;
	
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minXConstraint = leftmost.x + padding;
        maxXConstraint = rightmost.x - padding;
    }

	void Update () {
        Control();
    }

    void Control()
    {
        Vector3 newPosition = gameObject.transform.position;
        float movementSpeed = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += Vector3.left * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += Vector3.right * movementSpeed;
        }

        newPosition.x = Mathf.Clamp(newPosition.x, minXConstraint, maxXConstraint);
        gameObject.transform.position = newPosition;

    }
}
