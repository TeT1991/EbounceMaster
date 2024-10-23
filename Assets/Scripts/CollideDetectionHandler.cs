using UnityEngine;

public class CollideDetectionHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private IInteractable[] _collidebles;

    private void Awake()
    {
        Initialize();
    }

    private void ActivateCollidebleItem(IInteractable item, Vector3 position)
    {
        item.Activate(position);
    }

    private void Initialize()
    {
        _ball.Collided += ActivateCollidebleItem;
    }
}
