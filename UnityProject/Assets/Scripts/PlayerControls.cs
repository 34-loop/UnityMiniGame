using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public GameObject joyStickPrefab;

    public float tTL =0.5f;
    //Внутренний таймер мыши
    public float timer;
    //Мозг мыши

    public bool notSpawned =true;

 

    void SimpleTimer()
    {
        timer+=Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        timer =0;

    }


    // Update is called once per frame
    void Update()
    {
        SimpleTimer();

        var mControl = Mouse.current;
        var leftCLick = mControl.leftButton.isPressed;
        
        if (leftCLick)
        {
            if (notSpawned)
            {
                Vector3 mousePos = mControl.position.ReadValue();
                var wPoint =Camera.main.ScreenToWorldPoint(mousePos);
                Instantiate(joyStickPrefab, new Vector3(wPoint.x,wPoint.y,0.0f), Quaternion.identity);
                notSpawned=false;
            }

            //clickUpdate
            if(timer>tTL)
            {
                notSpawned=true;
                timer=0;
            }
        }

    }
}
