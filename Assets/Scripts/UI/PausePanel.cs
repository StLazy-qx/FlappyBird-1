using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private PauseHandler _pauseHandler;

    private float StopTime = 0;
    private float ContinueTime = 1;

    private void Start()
    {
        Close();
    }

    public void Close()
    {
        Time.timeScale = ContinueTime;

        gameObject.SetActive(false);
    }

    public void Open()
    {
        Time.timeScale = StopTime;

        gameObject.SetActive(true);
    }
}