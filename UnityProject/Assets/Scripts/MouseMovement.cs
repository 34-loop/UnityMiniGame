using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public MapBorders map;
    //Время сколько ходить
    public int timeToWait = 3;
    public int timeToWalk = 2;

    //Скорость мыши
    public float speed = 1.0f;

    //Внутренний таймер мыши
    public float timer;
    //Мозг мыши
    public bool wait=true;


    //Цель движения мыши
    private Vector3 destination;


    //Генератор случайных чисел
    private System.Random randObj;

    float NextFloat(System.Random random)
    {

        return (float)((random.NextDouble()-0.5));
    }


        
    void findNewDestination()
    {
        destination= new Vector3(map.maxx*NextFloat(randObj),map.maxy*NextFloat(randObj),0);
    }


    void Walk()
    {
        transform.position= transform.position + speed * (destination-transform.position) * Time.deltaTime;
    }

    void Think()
    {
        SimpleTimer();
        if (wait)
        {
            if(timer>timeToWait)
            {
                findNewDestination();
                timer=0;
                wait=false;
            }
        }
        else
        {
            if(timer>timeToWalk)
            {
                timer=0;
                wait=true;
            }
        }
    }

    void SimpleTimer()
    {
        timer+=Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        randObj = new System.Random();
        timer = timeToWait*NextFloat(randObj);
        
    }

    // Update is called once per frame
    void Update()
    {
        Think();
        if (!wait)
        {
            Walk();
        }
    }
}
