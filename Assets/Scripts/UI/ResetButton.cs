using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ResetButton : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private Bird _bird;
    [SerializeField] private EnemySpawner _enemySpawner;

    private Button _button;

    private void Awake() 
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _bird.Reset();
        _enemySpawner.Reset();
        _pausePanel.Close();
    }
}