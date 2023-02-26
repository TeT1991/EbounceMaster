using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected BallJumper _ball;

    public virtual void CollideAction()
    {
    }

    public virtual void FixedUpdate()
    {

    }

    public void LoadBall()
    {
        _ball = FindObjectOfType<BallJumper>(); 
    }
}
