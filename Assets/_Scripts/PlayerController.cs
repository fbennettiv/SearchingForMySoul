using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum eMode { idle, move, turn, dash, fall, death, invincible, roomTrans }

    [Header("Inscribed")]
    public float speed = 5;
    public float dashMult = 1.5f;
    public float invincibleDuration = 0.5f;

    [Header("Dynamic")]
    // Direction of held movement key
    public int dirHeld = -1;
    // Direction Dray is facing
    public int facing = 1;
    private int respawnFacing;
    private float roomTransDone = 0;
    private Vector3 respawnLoc;
    public eMode mode = eMode.idle;
    private KeyCode dashKey = KeyCode.X;

    private Vector2[] directions = new Vector2[] {Vector2.right, Vector2.up,
        Vector2.left, Vector2.down};
    private KeyCode[] keys = new KeyCode[] {
        KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow,
        KeyCode.D, KeyCode.W, KeyCode.A, KeyCode.S};
    
    private Rigidbody2D rigid;
    private Animator anim;
    private Stats stats;

    private bool death = false;
    private bool invincible = false;
    private float invincibleDone = 0;
    
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        stats = GetComponent<Stats>();
    }

    // Start is called before the first frame update
    void Start()
    {
        respawnLoc = transform.position;
        respawnFacing = facing;
        stats.health = stats.maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (death)
        {
            rigid.velocity = Vector2.zero; anim.speed = 0;
            return;
        }

        // Check invincibility
        if (invincible && Time.time > invincibleDone)
            invincible = false;

        if (mode == eMode.roomTrans)
        {
            rigid.velocity = Vector3.zero;
            anim.speed = 0;

            if (Time.time < roomTransDone) return;

            mode = eMode.idle;
        }

        // Movement
        if (mode == eMode.idle || mode == eMode.move)
        {
            dirHeld = -1;
            // Switch to switchcase
            for (int i = 0; i < keys.Length; i++)
            {
                if (Input.GetKey(keys[i])) dirHeld = i % 4;
            }

            // Turning
            if (dirHeld == 0 && facing == 2 || dirHeld == 2 && facing == 0) { mode = eMode.turn; }
            if (facing == 0) transform.rotation = Quaternion.identity;
            if (facing == 2) transform.rotation = Quaternion.Euler(0, -180, 0);

            if (dirHeld == -1)
            {
                mode = eMode.idle;
            }
            else
            {
                facing = dirHeld;
                mode = eMode.move;
            }
        }

        // Animation 
        Vector2 vel = Vector2.zero;
        switch (mode)
        {
            case eMode.idle:
                anim.Play("Player_Idle");
                anim.speed = 1;
                break;
            case eMode.move:
                vel = directions[dirHeld];
                anim.Play("Player_Run");
                anim.speed = 1;
                break;
            case eMode.turn:
                vel = directions[dirHeld];
                anim.Play("Player_Turn");
                break;
            case eMode.dash:
                vel = directions[dirHeld] * dashMult;
                anim.Play("Player_Dash");
                break;
            case eMode.death:
                vel = Vector2.zero;
                anim.Play("Player_Die");
                break;
        }

        rigid.velocity = vel * speed;
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (invincible) return;
        //health -= damage;
        if (stats.health <= 0) Die();
        if (death) return;
        invincible = true;
        invincibleDone = Time.time + invincibleDuration;
    }

    public void ResetInRoom(int healthLoss = 0)
    {
        transform.position = respawnLoc;
        facing = respawnFacing;
        stats.health -= healthLoss;

        invincible = true;
        invincibleDone = Time.time + invincibleDuration;
    }

    public void Die()
    {
        death = true;
    }
}
