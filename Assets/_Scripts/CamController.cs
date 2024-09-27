using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    static public bool TRANSITIONING { get; private set; }

    public float transTime = 0.5f;

    private Vector3 p0, p1;
    private float transStart;

    void Awake()
    {
        TRANSITIONING = false;
    }

    void Update()
    {
        // Placeholder inputs
        if (Input.GetKeyDown(KeyCode.T) && !TRANSITIONING) { TransitionTo(Vector3.up); }
        if (Input.GetKeyDown(KeyCode.G) && !TRANSITIONING) { TransitionTo(Vector3.down); }
        if (Input.GetKeyDown(KeyCode.F) && !TRANSITIONING) { TransitionTo(Vector3.left); }
        if (Input.GetKeyDown(KeyCode.H) && !TRANSITIONING) { TransitionTo(Vector3.right); }

        if (TRANSITIONING)
        {
            float u = (Time.time - transStart) / transTime;

            if (u >= 1)
            {
                u = 1;
                TRANSITIONING = false;
            }
            transform.position = (1 - u) * p0 + u * p1;
        }
        else
        {
            // If player is not in the room, transition to player
        }
    }

    void TransitionTo(Vector3 rm)
    {
        p0 = transform.position;

        p1 = transform.position + (rm * 10);

        transStart = Time.time;
        TRANSITIONING = true;
    }
}
