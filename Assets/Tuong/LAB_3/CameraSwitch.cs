using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera vCam1;  
    public CinemachineVirtualCamera vCam2;  
    bool camSwitched = false;
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftControl))
    //    {
    //        SwitchCam(false);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            SwitchCam(true);  
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            SwitchCam(false);  
        }
    }
    void SwitchCam(bool isColliding)
    {
        if (!camSwitched)
        {
            vCam1.m_Priority = 5;
            vCam2.m_Priority = 10;
            camSwitched = true;
        }
        else
        {
            vCam1.m_Priority = 10;
            vCam2.m_Priority = 5;
            camSwitched = false;
        }
    }
}


