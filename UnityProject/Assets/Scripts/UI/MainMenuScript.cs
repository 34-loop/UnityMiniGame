using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button startButton;
    public Button options;
    public Button exit;
    

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("start-button");
        startButton.clicked += StartGame;


    }
    
    


    void StartGame() 
    {

        Debug.Log("Game Started");
        SceneManager.LoadScene("MouseScene");  
    }
    
}
