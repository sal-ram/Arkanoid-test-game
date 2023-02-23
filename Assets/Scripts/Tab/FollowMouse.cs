using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 _mousePosition;

    private float _leftLimit = 3.8f;
    private float _rightLimit = -3.8f;

    private float _screenToCameraDistance;

    [SerializeField] private StartGameHandler startGameHandler;

    private void OnEnable()
    {
        startGameHandler.onGameStarted += DetachChildren;
    }

    private void OnDisable()
    {
        startGameHandler.onGameStarted -= DetachChildren;
    }


    // Start is called before the first frame update
    void Start()
    {
        _screenToCameraDistance = -Camera.main.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = GetMousePosition();

        FollowMousePosition();
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Input.mousePosition;

        var mousePositionNearClipPlane = new Vector3(mousePosition.x, mousePosition.y, _screenToCameraDistance);

        var position = Camera.main.ScreenToWorldPoint(mousePositionNearClipPlane);

        return position;
    }

    private void FollowMousePosition()
    {
        var limitedPosition = Mathf.Clamp(-_mousePosition.x, _rightLimit, _leftLimit);
        transform.position = new Vector3(limitedPosition, transform.position.y, transform.position.z);
    }

    private void DetachChildren()
    {
        transform.DetachChildren();
    }
}
