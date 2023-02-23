using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReflection : MonoBehaviour
{
    private float _centerOfTabX;
    private float _coeff;
    private float _magnitude;
    private Vector3 _reflectionVector;

    private void OnCollisionEnter(Collision collision)
    {
        var otherGameObject = collision.gameObject;

        if (otherGameObject.CompareTag("Ball"))
        {
            var otherRigidbody = otherGameObject.GetComponent<Rigidbody>();
            _magnitude = otherRigidbody.velocity.magnitude; //find the speed of collided ball to reflect it with the same force

            _centerOfTabX = GetCenterOfObject();   // find the center of tab in world coordinates
            var contact = collision.GetContact(0);

            _coeff = contact.point.x - _centerOfTabX;  // coeff is showing how far the ball contacted from tabs center

            _reflectionVector = CreateReflectionVector(_coeff, _magnitude); 

            otherRigidbody.velocity = _reflectionVector;
        }
    }

    private float GetCenterOfObject()
    {
        var centerOfTabLocal = GetComponent<BoxCollider>().center;

        var centerOfTabWorld = transform.TransformPoint(centerOfTabLocal);

        return centerOfTabWorld.x;
    }

    private Vector3 CreateReflectionVector(float coeff, float magnitude)
    {
        var reflectionVector = new Vector3(coeff, 0, -1) * magnitude;

        return reflectionVector;
    }
}
