using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private ContinueButton _continueButton;

    private void Start()
    {
        CLose();
        _bird.GameOver += Open;
    }

    public void CLose()
    {
        Time.timeScale = 1;

        gameObject.SetActive(false);
    }

    public void Open()
    {
        Time.timeScale = 0; 

        gameObject.SetActive(true);
    }

    public void DisableContinueButton()
    {
        _continueButton.gameObject.SetActive(false);
    }

    public void EnableContinueButton()
    {
        _continueButton.gameObject.SetActive(true);
    }
}
