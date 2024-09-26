using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    public bool isFacingRight = false;


    [Header("Enemy")]
    public int damage = 1;
    //knockback?

    public void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if ( coll.tag == "Player")
        {
            //damage
        }
    }
}
