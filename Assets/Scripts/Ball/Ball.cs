using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public event Action<IInteractable> Collided;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            Collided?.Invoke(interactable);
        }
    }
}
