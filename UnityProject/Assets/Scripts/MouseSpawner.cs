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


    //Generate random float between -0.5 and 0.5
    float NextFloat(System.Random random)
    {

        return (float)((random.NextDouble()-0.5));
    }


    Vector3 findNewSpawnPoint()
    {
        return new Vector3(map.maxx*2*NextFloat(randObj),map.maxy*2*NextFloat(randObj),0);
    }


    void SpawnMouseInRandomPosition()
    {
        if (timeToSpawn)
        {
            if (mouseCounter<maxMouse)
            {
                Instantiate(mousePrefab, findNewSpawnPoint(), Quaternion.identity);
                mouseCounter++;
            }
        }
    }

    void SpawnMouseOnTheEdges()
    {
        if (timeToSpawn)
        {
            if (mouseCounter<maxMouse)
            {
                Instantiate(mousePrefab, new Vector3(map.maxx,map.maxy,0), Quaternion.identity);
                Instantiate(mousePrefab, new Vector3(map.maxx,map.miny,0), Quaternion.identity);
                Instantiate(mousePrefab, new Vector3(map.minx,map.maxy,0), Quaternion.identity);
                Instantiate(mousePrefab, new Vector3(map.minx,map.miny,0), Quaternion.identity);
                mouseCounter++;
            }
        }
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
        SpawnMouseInRandomPosition();
        //SpawnMouseOnTheEdges();
    }
}
