using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputField;

    [SerializeField]
    TMP_Text text;

    [SerializeField]
    Button button;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
        inputField.onSubmit.AddListener(OnTextSubmit);

        text.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
    }

    void OnButtonClick()
    {
        text.gameObject.SetActive(!text.IsActive());
        ToggleButtonText();
    }

    void OnTextSubmit(string input)
    {
        text.text = input;
        inputField.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        ToggleButtonText();
    }

    void ToggleButtonText()
    {
        string buttonText = text.IsActive() ? "Hide Name" : "Show Name";
        button.GetComponentInChildren<TMP_Text>().text = buttonText;
    }
}

// Someone get back to me telling me if there's a way to use custom UI datatypes in the inspector!
//public class CustomText : TMP_Text
//{
//    protected override void OnEnable()
//    {
//        Debug.Log("Text enabled");
//    }
//
//    protected override void OnDisable()
//    {
//        Debug.Log("Text disabled");
//    }
//}
