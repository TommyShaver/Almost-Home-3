using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameOverCamera : MonoBehaviour
{
    [SerializeField] GameObject _vitruaCamera;

    public void GameOverCameraState()
    {
        _vitruaCamera.GetComponent<CinemachineVirtualCamera>().enabled = true;
        Debug.Log("<color=teal>Camera</color>: This fuction was called.");
    }
}
