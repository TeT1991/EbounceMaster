using UnityEngine;

[RequireComponent(typeof(SegmentsSwitcher))]
public class Platform : MonoBehaviour, IInteractable
{
    [SerializeField] private LayerMask _layerMask;

    private int _dangersCount = 5;
    private SegmentsSwitcher _segmentsSwitcher;

    private void Start()
    {
        Initialize();
    }

    private void InitSegments(int dangerCount)
    {
        _segmentsSwitcher.ResetStatus();
        _segmentsSwitcher.SetDangerSegments(_dangersCount);    
    }

    public void Activate(Vector3 position)
    {
        float rayLenght = 2000;
        Debug.Log("PLATFORM ACTIVATED");

        if(Physics.Raycast(position, Vector3.down, out RaycastHit raycastHit, rayLenght, _layerMask) )
        {
            Segment segment = raycastHit.collider.gameObject.GetComponent<Segment>();

            _segmentsSwitcher.ResetStatus();
            _segmentsSwitcher.SwitchStatus(segment, SegmentTypes.Danger);
            _segmentsSwitcher.SetDangerSegments(_dangersCount);
        }
    }

    private void Initialize()
    {
        _segmentsSwitcher = GetComponent<SegmentsSwitcher>();
        InitSegments(_dangersCount);
    }
}
