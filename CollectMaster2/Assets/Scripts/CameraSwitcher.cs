using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cameras;
    private int currentCameraIndex = 0;

    public void SwitchCamera(int newCameraIndex)
    {
        // Eski kamerayı pasif hale getir
        cameras[currentCameraIndex].Priority = 0;
        // Yeni kamerayı etkin hale getir
        cameras[newCameraIndex].Priority = 10;
        currentCameraIndex = newCameraIndex;
    }
}
