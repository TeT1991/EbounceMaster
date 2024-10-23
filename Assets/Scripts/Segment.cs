using UnityEngine;

public class Segment : MonoBehaviour
{
    public SegmentTypes _type;

    public SegmentTypes Type => _type;

    public void SetType(SegmentTypes type)
    {
        _type = type;
    }
}
