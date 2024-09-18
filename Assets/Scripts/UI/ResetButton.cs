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
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _pausePanel.Close();
        _bird.Reset();
        _enemySpawner.Reset();
    }
}