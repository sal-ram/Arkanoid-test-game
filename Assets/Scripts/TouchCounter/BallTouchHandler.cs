using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTouchHandler : MonoBehaviour
{
    public delegate void OnBallTouch(int num);
    public OnBallTouch onBallTouch;

    private int _counterOfTouches = 0;

    private void Start()
    {
        onBallTouch.Invoke(_counterOfTouches);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _counterOfTouches++;
            onBallTouch.Invoke(_counterOfTouches);
        }
    }
}
