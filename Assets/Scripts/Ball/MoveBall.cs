using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    private Rigidbody _rgbody;
    private float _maxSpeed = 7.5f;
    private float _force = 5;
    [SerializeField] private StartGameHandler startGameHandler;

    private void OnEnable()
    {
        startGameHandler.onGameStarted += ThrowBall;
    }

    private void OnDisable()
    {
        startGameHandler.onGameStarted -= ThrowBall;
    }

    void Start()
    {
        _rgbody = GetComponent<Rigidbody>();
        _rgbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        _rgbody.velocity = Vector3.ClampMagnitude(_rgbody.velocity, _maxSpeed);
    }

    private void ThrowBall()
    {
        _rgbody.isKinematic = false;
        _rgbody.velocity = new Vector3(Random.Range(-0.5f, 0.5f), 0, -1) * _force;
    }
}
