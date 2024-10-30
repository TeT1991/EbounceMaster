using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollideHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    private void Awake()
    {
        _ball.Collided += Interact;
    }

    private void Interact(IInteractable interactable)
    {
        interactable.Interact(_ball.gameObject.transform.position);
    }
}
