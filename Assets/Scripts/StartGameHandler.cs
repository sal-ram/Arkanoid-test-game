using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameHandler : MonoBehaviour
{
    private bool IsGameStarted = false;

    public delegate void OnGameStarted();
    public OnGameStarted onGameStarted;

    private void Update()
    {
        if (!IsGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsGameStarted = true;
                onGameStarted.Invoke();
            }
        }
    }
}
