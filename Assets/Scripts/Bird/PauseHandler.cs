using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private BirdShooter _birdShooter;
    [SerializeField] private InputReader _inputPauseKey;
    [SerializeField] private PausePanel _pausePanel;

    public bool IsPaused { get; private set; }

    private void Awake()
    {
        IsPaused = false;
    }

    private void OnEnable()
    {
        _inputPauseKey.PauseKeyPressing += TogglePause;
        _bird.GameOvered += StopGame;
        _bird.Reseting += ContinueGame;
    }

    private void OnDisable()
    {
        _inputPauseKey.PauseKeyPressing -= TogglePause;
        _bird.GameOvered -= StopGame;
        _bird.Reseting -= ContinueGame;
    }

    private void TogglePause()
    {
        IsPaused = !IsPaused;

        if (_bird.IsLive)
        {
            if (IsPaused)
                StopGame();
            else
                ContinueGame();
        }
    }

    public void StopGame()
    {
        _pausePanel.Open();

        IsPaused = true;
        _birdMover.enabled = false;
        _birdShooter.enabled = false;
    }

    public void ContinueGame()
    {
        _pausePanel.Close();

        IsPaused = false;
        _birdMover.enabled = true;
        _birdShooter.enabled = true;
    }
}