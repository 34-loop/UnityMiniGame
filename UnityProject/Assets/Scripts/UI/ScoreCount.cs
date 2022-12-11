using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreCount : MonoBehaviour
{
    public int scoreCount;
    public Label score;
    
   

    // Start is called before the first frame update
    public void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        scoreCount = 0;
        score = root.Q<Label>("score-count");
        score.text = "Score: " + scoreCount;
        
    }
    public void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "PlayerClick")
        {
            Debug.Log("Scored!");
            scoreCount++;
            score.text = "Score: " + scoreCount;
        }
       

    }






}
