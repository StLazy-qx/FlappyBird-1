using UnityEngine;

[RequireComponent(typeof(Bird))]

public class BirdCollitionHandler : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;

    private Bird _bird;

    private void Awake()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<GroundZone>(out _))
        {
            _bird.Destroy();
        }
    }
}