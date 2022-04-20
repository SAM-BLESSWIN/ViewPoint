using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamera : MonoBehaviour
{ 
public static PlayerCamera _instance;
[SerializeField] private CinemachineVirtualCamera _2dcam;
[SerializeField] private CinemachineVirtualCamera topdowncam;

void Update()
{
        SwitchCamera();
}

private void SwitchCamera()
{
    if (Input.GetKeyDown(KeyCode.C))
    {
        if (_2dcam.gameObject.activeSelf)
        {
            _2dcam.gameObject.SetActive(false);
            topdowncam.gameObject.SetActive(true);
        }
        else if (topdowncam.gameObject.activeSelf)
        {
            topdowncam.gameObject.SetActive(false);
            _2dcam.gameObject.SetActive(true);
        }
    }
}
}
