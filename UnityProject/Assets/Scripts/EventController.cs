using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public delegate void EventHandler(); 
    public event EventHandler OnMouseKilled;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Working");
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerClick"))
        {
            OnMouseKilled?.Invoke();
        }
        
    }
}
