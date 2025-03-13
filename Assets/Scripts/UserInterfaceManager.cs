using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
        inputField.onSubmit.AddListener(OnInputSubmit);
        button.onClick.AddListener(OnButtonClick);

        text.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
    }

    // Runs when button is clicked
    void OnButtonClick()
    {
        ToggleButtonText();
    }

    // Runs when ENTER is pressed
    void OnInputSubmit(string input)
    {
        // Stores user text and shows/hides UI elements
        text.text = input;
        inputField.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        button.gameObject.SetActive(true);

        // Made this into a function since it needs to be done once on-input submit,
        // and every time we click our button (every time we change our text status)
        ToggleButtonText();
    }

    void ToggleButtonText()
    {
        // Toggle text visible/invisible
        text.gameObject.SetActive(!text.gameObject.activeSelf);

        // Change button message depending on text status
        string buttonText = text.gameObject.activeSelf ? "Hide Name" : "Show Name";
        button.GetComponentInChildren<TMP_Text>().text = buttonText;
    }
}
