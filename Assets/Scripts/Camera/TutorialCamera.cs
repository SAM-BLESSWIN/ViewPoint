using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TutorialCamera : MonoBehaviour
{
    public static TutorialCamera _instance;
    [SerializeField] private CinemachineVirtualCamera _2dcam;
    [SerializeField] private CinemachineVirtualCamera topdowncam;

    private bool bCanswitchcam=false;
    public bool CanSwitchCamera
    { set { bCanswitchcam = value; } }

    private bool bcamswitched;
    public bool CamSwitched
    { get { return bcamswitched; } }

    void Update()
    {
        if(TutorialManager.Instance.IsInTutorial)
        {
            if(bCanswitchcam)
            {
                SwitchCamera();
            }
        }
        else
        {
            SwitchCamera();
        }

    }

    private void SwitchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            bcamswitched = true;
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
