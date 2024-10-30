using UnityEngine;

public class SegmentRenderer : MonoBehaviour
{
    [SerializeField] private Color _safeColor;
    [SerializeField] private Color _bonusColor;
    [SerializeField] private Color _dangerColor;

    public void Render(Segment segment)
    {
        if(segment.TryGetComponent<Renderer>(out Renderer renderer))
        {
            renderer.material.color = GenerateColor(segment.Type);
        }
    }

    private Color GenerateColor(SegmentTypes type)
    {
        var color = type switch
        {
            SegmentTypes.Bonus => _bonusColor,
            SegmentTypes.Danger => _dangerColor,
            _ => _safeColor,
            
        };

        return color;
    }
}
