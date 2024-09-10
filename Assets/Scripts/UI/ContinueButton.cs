using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private PauseHandler _pauseHandler;
    [SerializeField] private Bird _bird;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        if (_button != null)
            _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _pausePanel.Close();
        _pauseHandler.ContinueGame();
    }

    private void OnEnable()
    {
        _bird.GameOvered += Deactivate;
        _bird.Reseting += Activate;
    }

    private void OnDisable()
    {
        _bird.GameOvered -= Deactivate;
        _bird.Reseting -= Activate;
    }

    private void Deactivate()
    {
        _button.interactable = false;
    }

    private void Activate()
    {
        _button.interactable = true;
    }
}