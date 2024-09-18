using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private float _stopTime = 0;
    private float _continueTime = 1;

    private void Awake()
    {
        Close();
    }

    public void Close()
    {
        gameObject.SetActive(false);

        Time.timeScale = _continueTime;
    }

    public void Open()
    {
        gameObject.SetActive(true);

        Time.timeScale = _stopTime;
    }
}