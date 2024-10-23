using UnityEngine;

public class SegmentsRenderer : MonoBehaviour
{
    [SerializeField] private Color _safeColor;
    [SerializeField] private Color _dangerColor;
    [SerializeField] private Color _bonusColor;

    public void Render(Segment segment)
    {
        Renderer renderer = segment.GetComponent<Renderer>();
        renderer.material.color = GetColor(segment.Type);
    }

    private Color GetColor(SegmentTypes type)
    {
        var color = type switch
        {
            SegmentTypes.Danger => _dangerColor,
            SegmentTypes.Bonus => _bonusColor,
            SegmentTypes.Safe => _safeColor,
        };

        return color;
    }
}
