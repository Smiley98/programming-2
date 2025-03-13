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
        text.gameObject.SetActive(!text.gameObject.activeSelf);
    }

    void OnTextSubmit(string input)
    {
        text.text = input;
        button.GetComponentInChildren<TMP_Text>().text = "Show Name";
        inputField.gameObject.SetActive(false);
        text.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
    }
}
