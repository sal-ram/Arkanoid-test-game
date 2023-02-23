using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
    private Rigidbody _rgbody;
    private float _force;

    // Start is called before the first frame update
    void Start()
    {
        _rgbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _force = _rgbody.velocity.magnitude;

        var vectorPerpendic = Vector2.Perpendicular(new Vector2(_rgbody.velocity.x, _rgbody.velocity.z)); // find the perpendicular vector to velocity vector

        _rgbody.AddTorque(- new Vector3(vectorPerpendic.x, 0, vectorPerpendic.y) * _force); // toraue ball around founded vector 
    }    
}
