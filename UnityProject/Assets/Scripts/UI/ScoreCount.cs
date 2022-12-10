using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreCount : MonoBehaviour
{
    public int scoreCount;
    public Label score;
    public Button testButton;


    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
        var root = GetComponent<UIDocument>().rootVisualElement;
        score = root.Q<Label>("score-count");
        testButton = root.Q<Button>("test-button");
        testButton.clicked += AddScore;
    }
    public void AddScore() {

        scoreCount++;
        score.text = "Score: " + scoreCount;

       
    }
    
    
}
