using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private Bird _bird;

    private KeyCode _pauseKey = KeyCode.Escape;
    private bool _isPaused = false;

    public bool IsPaused => _isPaused;

    private void Update()
    {
        if (_bird.IsLive)
        {
            if (Input.GetKeyDown(_pauseKey))
            {
                TogglePause();
            }
        }

        if (_bird.IsLive == false)
        {
            _isPaused = true;
            _pausePanel.DisableContinueButton();
        }
    }

    private void TogglePause()
    {
        _isPaused = !_isPaused;

        if(_isPaused)
        {
            _pausePanel.Open();
        }
        else
        {
            _pausePanel.CLose();
        }
    }

    public void ContinueGame()
    {
        if (_bird.IsLive == false)
            return;

        _isPaused = false;
    }
}
