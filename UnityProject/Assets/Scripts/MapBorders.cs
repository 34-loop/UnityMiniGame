using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBorders : MonoBehaviour
{
    public float minx = 0.0f;
    public float maxx = 10.0f;
    public float miny = 0.0f;
    public float maxy = 10.0f;

    private bool loadBorders = false;

    void LoadMapBorders()
    {
        maxx = gameObject.transform.GetChild(1).position.x;
        maxy = gameObject.transform.GetChild(1).position.y;
        minx= -maxx;
        miny=-maxy;
        loadBorders=true;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadMapBorders();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
