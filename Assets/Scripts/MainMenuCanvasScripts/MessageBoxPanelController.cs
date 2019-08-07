using UnityEngine.UI;
using UnityEngine;

public class MessageBoxPanelController : MonoBehaviour
{
    public static MessageBoxPanelController Instance { get; private set; }

    [SerializeField] private TMPro.TextMeshProUGUI _messageText;
    [SerializeField] private TMPro.TextMeshProUGUI _titleText;
    [SerializeField] private Button _okButton;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _okButton.onClick.AddListener(OnOkButtonClick);
    }
    private void OnOkButtonClick()
    {
        MainMenuController.Instance.OnHideMessage();
    }
    public void ShowMessage(string title, string message)
    {
        _titleText.text = title;
        _messageText.text = message;
        MainMenuController.Instance.OnShowMessage();
    }
}
