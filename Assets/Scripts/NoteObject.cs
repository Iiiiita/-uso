using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public bool noteHasBeenHit;
    public KeyCode keyToPress;

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                noteHasBeenHit = true;     
                //Targettien y-position on 240 TASAN!!
                if (transform.position.y > 240.5 || transform.position.y < 239.95)
                {
                    //Debug.Log("PERFECT!!");
                    GameManager.instance.PerfectHit();
                    
                }
               /* /else if (transform.position.y > 240.05f || transform.position.y < 239.95f)
                {
                    Debug.Log("GOOD HIT!");
                    GameManager.instance.GoodHit();
                 
                }*/
                else if (transform.position.y > 240.20 || transform.position.y < 239.80)
                {
                   // Debug.Log("HIT!");
                    GameManager.instance.NormalHit();
                    
                }
               
                DestroyGameObject();
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Target")
        {
            canBePressed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Target")
        {
            canBePressed = false;
            if (!noteHasBeenHit) 
            GameManager.instance.NoteMissed();
            DestroyGameObject();
        }
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
       // Debug.Log("Destroyed a Note!");
    }
}
