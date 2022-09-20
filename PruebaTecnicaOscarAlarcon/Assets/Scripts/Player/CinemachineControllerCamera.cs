using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineControllerCamera : MonoBehaviour
{
    public Cinemachine.CinemachineFreeLook freeAim;

    public float lookspeed;
    public void InputCamera()
    {
        if (!Player.Instance.IsActive)
            return;

        if (SimpleSampleCharacterControl.Instance.aimUse)
        {
            //freeAim.m_XAxis.Value += SimpleSampleCharacterControl.Instance.characterPlayerInput.GetHorizontalCameraInput() * lookspeed * Time.deltaTime;
            freeAim.m_YAxis.Value += SimpleSampleCharacterControl.Instance.characterPlayerInput.GetVerticalCameraInput() * Time.deltaTime;
            freeAim.m_YAxisRecentering.m_RecenteringTime = 15f;
            freeAim.m_YAxisRecentering.m_WaitTime = 30f;
        }
        else
        {
            freeAim.m_YAxis.Value += SimpleSampleCharacterControl.Instance.characterPlayerInput.GetVerticalCameraInput() * Time.deltaTime;
            freeAim.m_YAxisRecentering.m_RecenteringTime = 1f;
            freeAim.m_YAxisRecentering.m_WaitTime = 0.5f;

        }
    }

    public float GetHeightCamera()
    {
        return freeAim.m_YAxis.Value;
    }
}
