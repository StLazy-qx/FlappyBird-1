using UnityEngine;

public abstract class ObjectablePool : MonoBehaviour
{
    public bool IsActive => gameObject.activeSelf;

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    public virtual void Enable()
    {
        gameObject.SetActive(true);
    }

    public virtual void Disable()
    {
        gameObject.SetActive(false);
    }
}
