using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    //When Object interaction is made switch from ontrigger2d
    public GameObject Teleporter1;
    public GameObject Teleporter2;

    public GameObject Fading;

    private GameObject player;

    public int timetowait = 2;

    public float timer = 0;

    private bool tp1;
    private bool tp2;

    private bool tracker = true;
    
    public float offsety = 0.00f;
    public float offsetx = 0.00f;
    private void Update()
    {     
        if (tp1)
        {
            timer += Time.deltaTime;
            if (timer > timetowait)
            {
                player.gameObject.transform.position = new Vector2(Teleporter2.transform.position.x + offsetx, Teleporter2.transform.position.y + offsety);
                Fading.GetComponent<FadeInOut>().FadeOut();
                timer = 0;
                tp1 = false;
            }
        }
        if (tp2)
        {
            timer += Time.deltaTime;
            if (timer > timetowait)
            {
                player.gameObject.transform.position = new Vector2(Teleporter1.transform.position.x - offsetx, Teleporter1.transform.position.y - offsety);
                Fading.GetComponent<FadeInOut>().FadeOut();
                timer = 0;
                tp2 = false;
            }
        }    
         
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {         
            if (tracker == true)
            {
                tracker = false;               
                tp1 = true;
                Fading.GetComponent<FadeInOut>().FadeIn(); 
                player = collision.gameObject;
                return;
                                             
            }
            if (tracker == false)
            {
                tracker = true;
                tp2 = true;               
                Fading.GetComponent<FadeInOut>().FadeIn();
                player = collision.gameObject;
                return;                            
            }    
                
        }
    }
   
}
