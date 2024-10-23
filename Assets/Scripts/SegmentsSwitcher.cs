using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SegmentsRenderer))]
public class SegmentsSwitcher : MonoBehaviour
{
    [SerializeField] private List<Segment> _segments;

    private SegmentsRenderer _renderer;

    private void Awake()
    {
        Initialize();
    }

    public void ResetStatus()
    {
        foreach (Segment segment in _segments)
        {
            SwitchStatus(segment, SegmentTypes.Safe);
        }
    }

    public void SetDangerSegments(int dangersCount)
    {
        while (dangersCount > 0)
        {
            Segment segment = _segments[UserUtils.GenerateRandomNumber(_segments.Count - 1)];

            if (segment.Type != SegmentTypes.Danger)
            {
                SwitchStatus(segment, SegmentTypes.Danger);
                dangersCount--;
            }
        } 
    }

    public void SwitchStatus(Segment segment, SegmentTypes type)
    {
        segment.SetType(type);
        _renderer.Render(segment);
    }

    private void Initialize()
    {
        _renderer = GetComponent<SegmentsRenderer>();
    }
}
