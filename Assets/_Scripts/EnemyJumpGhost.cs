using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpGhost : EnemyController
{
    public GameObject startpoint;
    public GameObject stoppoint;

    public GameObject Door;

    public float jumpspeed = 1.0f;
    public float returnspeed = 1.0f;
    public int timetowait = 2;

    private float timer = 0;

    private bool isMoving = false;
    private bool isReturning = false;
    private bool canBeActivated = true;
    

    private void Update()
    {
        if (isMoving)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -jumpspeed));
        }
        if(isReturning)
        {
            timer += Time.deltaTime;
            if (timer > timetowait)
            {
                transform.position = Vector3.MoveTowards(transform.position, startpoint.transform.position, returnspeed * Time.deltaTime);
                if (GetComponent<Transform>().position == startpoint.transform.position)
                {
                    isReturning = false;
                    canBeActivated = true;
                    Door.active = true;
                    timer = 0;
                }
            }          
        }

    }   

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player" && canBeActivated)
        {
            canBeActivated = false;
            isMoving = true;
            Door.active = false;
        }

        if (collider.gameObject == stoppoint)
        {
            isMoving = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;           
            isReturning = true;
            
        }

    }
}
