using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolGhost : EnemyController
{
    public GameObject wayPointA;
    public GameObject wayPointB;

    public float speed = 1.0f;

    public bool shouldChangeFacing = false;

    private bool directionAB = false;

    void FixedUpdate()
    {
        if (transform.position == wayPointA.transform.position &&
             directionAB == false ||
             transform.position == wayPointB.transform.position &&
             directionAB == true)
        {
            directionAB = !directionAB;
            if (shouldChangeFacing)
            {
                gameObject.GetComponent<EnemyController>().Flip();
            }
        }
        if (directionAB)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                wayPointB.transform.position,
                speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                wayPointA.transform.position,
                speed * Time.fixedDeltaTime);
        }
    }
}
