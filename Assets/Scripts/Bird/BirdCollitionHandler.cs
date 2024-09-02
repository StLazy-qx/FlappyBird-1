using UnityEngine;

[RequireComponent(typeof(Bird))]

public class BirdCollitionHandler : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;

    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out GroundZone groundZone))
        {
            _bird.Destroy();
            _pausePanel.DisableContinueButton();
        }
    }
}
