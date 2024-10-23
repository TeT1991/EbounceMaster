using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJumper : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yAnimation;
    [SerializeField] private AnimationCurve _scaleAnimation;
    [SerializeField] private float _duration;
    [SerializeField] private float _height;

    private void OnCollisionEnter(Collision collision)
    {
        PlayAmimation();
    }

    public void PlayAmimation()
    {
         StartCoroutine(AnimationPlaying());
    }

    private IEnumerator AnimationPlaying()
    {
        float expiredSexonds = 0;
        float progress = 0;

        Vector3 startPosition = transform.position;

        while (progress < 1)
        {
            expiredSexonds += Time.deltaTime;
            progress = expiredSexonds / _duration;

            transform.position = startPosition + new Vector3(0, (float)_yAnimation.Evaluate(progress) * _height , 0);

            float scale = _scaleAnimation.Evaluate(progress);
            //transform.localScale = Vector3.one * _scaleAnimation.Evaluate(progress);

            yield return null;
        }
    }
}
