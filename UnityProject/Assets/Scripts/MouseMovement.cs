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



    void LookAt()
    {
        Vector2 mouseDir = new Vector2(0.0f,1.0f);
        Vector2 destination2 = (destination-transform.position);
        float lookAtAngle = Mathf.Rad2Deg*Mathf.Acos(Vector2.Dot(mouseDir,destination2)/destination2.magnitude);

        if(Vector2.Dot(mouseDir,destination2)>0)
        {
            lookAtAngle=-lookAtAngle;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0.0f,0.0f,lookAtAngle));
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
                LookAt();
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
