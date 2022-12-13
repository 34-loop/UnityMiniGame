using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerClick")
        {
            Destroy(gameObject);
            
        }
        
    }  

}
