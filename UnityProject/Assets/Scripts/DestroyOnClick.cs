using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    public EventController eventController;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerClick")
        {
            Destroy(gameObject);
            eventController.RegisterMouseKilled();
            
        }
        
    }  

}
