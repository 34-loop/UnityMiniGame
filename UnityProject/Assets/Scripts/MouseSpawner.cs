using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpawner : MonoBehaviour
{
    public MapBorders map;
    public GameObject mousePrefab;

    private System.Random randObj;
    private int mouseCounter;
    public int maxMouse;
    public int whichFrameToSpawnMouse = 0;
    public int whichTimeToSpawnMouse = 3;

    private bool timeToSpawn;
    private int frameCount;

    public float timer;

    void SimpleFrameCounter()
    {
        frameCount=(frameCount+1)%whichFrameToSpawnMouse;
        if (frameCount==0)
        {
            timeToSpawn=true;
        }
        else
        {
            timeToSpawn=false;
        }
    }

    void SimpleTimer()
    {
        timer+=Time.deltaTime;
        if (timer>whichTimeToSpawnMouse)
        {
            timer=0.0f;
            timeToSpawn=true;
        }
        else
        {
            timeToSpawn=false;
        }
    }

    float NextFloat(System.Random random)
    {

        return (float)((random.NextDouble()-0.5));
    }


    Vector3 findNewSpawnPoint()
    {
        return new Vector3(map.maxx*NextFloat(randObj),map.maxy*NextFloat(randObj),0);
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        randObj = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        SimpleTimer();
        if (timeToSpawn)
        {
            if (mouseCounter<maxMouse)
            {
                Instantiate(mousePrefab, findNewSpawnPoint(), Quaternion.identity);
                mouseCounter++;
            }
        }
    }
}
