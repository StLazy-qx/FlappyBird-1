using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private PauseHandler _pauseHandler;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        if (_button != null)
            _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _pauseHandler.ContinueGame();
        _pausePanel.CLose();
    }
}
