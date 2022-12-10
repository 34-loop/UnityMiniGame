using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class MyCustomEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_UXMLTree;

    [MenuItem("Window/UI Toolkit/MyCustomEditor")]
    public static void ShowExample()
    {
        MyCustomEditor wnd = GetWindow<MyCustomEditor>();
        wnd.titleContent = new GUIContent("MyCustomEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("These controls were created using C# code.");
        root.Add(label);

        Button button = new Button();
        button.name = "button3";
        button.text = "This is button3.";
        rootVisualElement.Add(button);

        Toggle toggle = new Toggle();
        toggle.name = "toggle3";
        toggle.label = "Number?";
        rootVisualElement.Add(toggle);


        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI Toolkit/test/MyCustomEditor.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);
        rootVisualElement.Add(m_UXMLTree.Instantiate());
    }
}