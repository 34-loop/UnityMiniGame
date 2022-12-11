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

    //Скорость поворота мыши в радианах
    public float rotSpeed = 10f;

    //Внутренний таймер мыши
    public float timer;
    //Мозг мыши
    public bool wait=true;
    public bool needToRotate=true;


    //Цель движения мыши
    private Vector3 destination;

    //Цель движения мыши
    private Vector3 targetAngle;


    //Генератор случайных чисел
    private System.Random randObj;

    float NextFloat(System.Random random)
    {

        return (float)((random.NextDouble()-0.5));
    }


        
    void FindNewDestination()
    {
        destination= new Vector3(map.maxx*NextFloat(randObj),map.maxy*NextFloat(randObj),0);
    }



    void FindLookAtAngle()
    {
        Vector2 mouseDir = new Vector2(0.0f,1.0f);
        Vector2 destination2 = (destination-transform.position);
        float lookAtAngle = Mathf.Rad2Deg*Mathf.Acos(Vector2.Dot(mouseDir,destination2)/destination2.magnitude);
        if(destination2.x>0)
        {
            lookAtAngle=-lookAtAngle;
        }
        targetAngle=new Vector3(0.0f,0.0f,lookAtAngle);

        
    }
    void Walk()
    {
        transform.position= transform.position + speed * (destination-transform.position) * Time.deltaTime;
    }

    void Rotate()
    {
       transform.rotation=Quaternion.Euler(targetAngle);
    }

    void Think()
    {
        SimpleTimer();
        if (wait)
        {
            if(timer>timeToWait)
            {
                FindNewDestination();
                FindLookAtAngle();
                timer=0;
                wait=false;
                needToRotate=true;
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
    }
    void FixedUpdate()
    {
        if (!wait)
        {
            if (needToRotate)
            {
                Rotate();
                needToRotate=false;
            }
            else
            {
                Walk();
            }
        }
    }
}
