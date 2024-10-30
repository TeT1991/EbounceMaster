using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SegmentRenderer))]
public class Platform : MonoBehaviour, IInteractable
{
    [SerializeField] private Segment[] _segments;
    [SerializeField] private LayerMask _layerMask;

    private SegmentRenderer _segmentRenderer;

    public Action<Segment> SegmentActivated;

    public void ResetSegments()
    {
        foreach (Segment segment in _segments)
        {
            segment.SetType(SegmentTypes.Safe);
            _segmentRenderer.Render(segment);
        }
    }

    public void SetDangerSegments(int count)
    {
        Debug.Log("SET");
        ResetSegments();

        for (int i = 0; i < count; i++)
        {
            bool inProgress = true;

            while (inProgress)
            {
                var segment = _segments[UserUtils.GenerateRandomNumber(0, _segments.Length)];

                if (segment.Type != SegmentTypes.Danger)
                {
                    SetSegmentType(segment, SegmentTypes.Danger);
                    inProgress = false;
                }
            }
        }
    }

    public void Initialize()
    {
        _segmentRenderer = GetComponent<SegmentRenderer>();
    }
    public void Interact(Vector3 position)
    {
        Segment segment = GetSegment(position);

        if (segment != null)
        {
            SegmentActivated?.Invoke(segment);
        }
    }

    public void SetSegmentType(Segment segment, SegmentTypes type)
    {
        segment.SetType(type);
        _segmentRenderer.Render(segment);
    }

    private Segment GetSegment(Vector3 position)
    {
        float rayLenght = 2000;

        Debug.DrawRay(position, Vector3.down);

        if (Physics.Raycast(position, Vector3.down, out RaycastHit hitInfo, rayLenght, _layerMask))
        {
            if (hitInfo.collider.gameObject.TryGetComponent<Segment>(out Segment segment))
            {
                return segment;
            }
        }

        return null;
    }
}
