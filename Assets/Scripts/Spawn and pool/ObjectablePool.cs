using UnityEngine;

public abstract class ObjectablePool : MonoBehaviour
{
    public bool IsActive => gameObject.activeSelf;

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
