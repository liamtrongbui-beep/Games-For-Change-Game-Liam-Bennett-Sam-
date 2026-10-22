using UnityEngine;
using UnityEngine.UIElements;

public class HUDController : MonoBehaviour
{
    private UIDocument uiDocument;
    private Label pressureLabel;

    void OnEnable()
    {
        // 1. Get the UIDocument component
        uiDocument = GetComponent<UIDocument>();

        // 2. Query the root visual element to find your Label by its Name
        pressureLabel = uiDocument.rootVisualElement.Q<Label>("HealthLabel");
        

        // 3. Set the initial text
        UpdatePressureUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePressureUI()
    {

    }

}
