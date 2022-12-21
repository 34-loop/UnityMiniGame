using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheeseButton : MonoBehaviour
{
    private Button _cheeseButton;
    public GameObject cheese;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _cheeseButton = root.Q<Button>("cheese-button");
        _cheeseButton.clicked += OnCheeseButtonClicked;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCheeseButtonClicked() 
    {
        Debug.Log("Cheese activated");
        GameObject.Instantiate<GameObject>(cheese);
 
    }




}
