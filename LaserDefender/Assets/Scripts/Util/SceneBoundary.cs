using UnityEngine;
using System.Collections;

public class SceneBoundary : MonoBehaviour{
    

    public static float minXConstraint = -6;
    public static float maxXConstraint = 6;
    
    void Start ()
    {
        // Distance to GameObject. for a 2D game, this will be constant
        float distance = -10;
        //float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minXConstraint = leftmost.x;
        maxXConstraint = rightmost.x;
    }

   
    public float GetMinX(float padding)
    {
        return minXConstraint - padding;
    }
    
    public float GetMaxX(float padding)
    {
        return maxXConstraint + padding;
    }
}
