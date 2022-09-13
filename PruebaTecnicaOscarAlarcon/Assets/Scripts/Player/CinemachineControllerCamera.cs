using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineControllerCamera : MonoBehaviour
{
    public Cinemachine.CinemachineFreeLook freeLook;
    public float lookspeed;

    public void FixedUpdate()
    {
        if (freeLook.gameObject.activeInHierarchy)
        {
            InputCamera();
        }
    }

    void InputCamera()
    {
        freeLook.m_XAxis.Value += SimpleSampleCharacterControl.Instance.characterPlayerInput.GetHorizontalCameraInput() * lookspeed * Time.deltaTime;
        freeLook.m_YAxis.Value += SimpleSampleCharacterControl.Instance.characterPlayerInput.GetVerticalCameraInput() * Time.deltaTime;
    }
}
