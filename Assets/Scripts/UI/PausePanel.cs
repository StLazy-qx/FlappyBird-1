using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private PauseHandler _pauseHandler;

    private float StopTime = 0;
    private float ContinueTime = 1;

    private void Awake()
    {
        Close();
    }

    public void Close()
    {
        gameObject.SetActive(false);

        Time.timeScale = ContinueTime;
    }

    public void Open()
    {
        gameObject.SetActive(true);

        Time.timeScale = StopTime;
    }
}