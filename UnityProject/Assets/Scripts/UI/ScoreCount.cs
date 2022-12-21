using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreCount : MonoBehaviour
{
    public int scoreCount;
    public Label score;
    public EventController eventController;
    public string scoreText;
    
   

    // Start is called before the first frame update
    public void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        scoreCount = 0;
        score = root.Q<Label>("score-count");
        
        eventController.OnMouseKilled += Scored_OnMouseKilled;

        
        
    }

    private void Scored_OnMouseKilled()
    {
        Debug.Log("Scored");
        scoreCount++;
        score.text = $"{scoreCount}";
        
    }

    public void Update()
    {
        
        
    }
     





}
