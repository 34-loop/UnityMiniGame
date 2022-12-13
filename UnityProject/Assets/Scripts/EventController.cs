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
        
    }

    // Update is called once per frame
    public void RegisterMouseKilled()
    {
        
            OnMouseKilled?.Invoke();
            Debug.Log("Test");
              
    }
}
