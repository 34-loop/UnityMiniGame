using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickTTL : MonoBehaviour
{
    public float tTL =0.5f;
    //Внутренний таймер мыши
    public float timer;
    //Мозг мыши


 

    void SimpleTimer()
    {
        timer+=Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        SimpleTimer();
        if (timer>tTL)
        {
            Destroy(gameObject);
        }
    }
}
