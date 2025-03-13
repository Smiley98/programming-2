using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    Button button;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        Debug.Log("Button clicked!");
        text.enabled = !text.enabled;
    }
}
