using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPH : MonoBehaviour
{
    Transform playerpos;
    Rigidbody2D rb;
    public float speed = 1.0f;
    private void Awake()
    {
        playerpos = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(movex * speed, movey * speed);


    }
}
