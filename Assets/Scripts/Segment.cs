using UnityEngine;

public class Segment : MonoBehaviour
{
    private SegmentTypes _type;

    public SegmentTypes Type => _type;

    public void SetType(SegmentTypes type)
    {
        _type = type;
    }
}
