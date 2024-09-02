using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ResetButton : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private Bird _bird;
    [SerializeField] private EnemyPool _pool;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        if (_button != null)
            _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _pausePanel.CLose();
        _pausePanel.EnableContinueButton();
        _bird.Reset();
        _pool.Reset();
    }
}
