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
    }

    void OnButtonClick()
    {
        text.gameObject.SetActive(!text.gameObject.activeSelf);
    }

    void OnTextSubmit(string input)
    {
        text.text = input;
    }
}
