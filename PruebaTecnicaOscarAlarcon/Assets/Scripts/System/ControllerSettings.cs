using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSettings : MonoBehaviour
{
    [SerializeField]
    Slider sliderVoluemSettings;
    [SerializeField]
    Dropdown dropdownGrapichsSettings;
    int valueQuality = 3;
    [SerializeField]
    Toggle toggleUiTouch;

    void Start()
    {
        float valueVolumen;
        SoundManager.Instance.audioMixer.GetFloat(Tags.VOLUMENMASTER_TAG, out valueVolumen);
        sliderVoluemSettings.value = valueVolumen;
        SetQualitySettings(valueQuality);
        toggleUiTouch.onValueChanged.AddListener(delegate { SetBoolStateUITouch(toggleUiTouch); });
    }

    /// <summary>
    /// Método que permite cambiar por medio de dropdown la calidad de graficas.
    /// </summary>
    /// <param name="qualityIndex">Numero de calidad grafica segun ployect settings.</param>
    public void SetQualitySettings(int qualityIndex)
    {
        ScenesManager.Instance.SetQuality(qualityIndex);
    }
    public void Mute()
    {
        SoundManager.Instance.MuteAudio();
    }

    public void PauseController()
    {
        ScenesManager.Instance.Pause();
    }

    /// <summary>
    /// Método que permite cambiar por medio de un slider el volumen actual.
    /// </summary>
    /// <param name="value">Numero de volumen que queremos cambiar.</param>
    public void SetVolumenSettings(float value)
    {
        SoundManager.Instance.SetVolume(value);
    }

    /// <summary>
    /// Método que permite cambiar por medio de un bool el estado de la ui de touch.
    /// </summary>
    public void SetBoolStateUITouch(Toggle toggle)
    {
        ScenesManager.Instance.touchdBuild = toggle.isOn;
        ScenesManager.Instance.EditTouchSystem(ScenesManager.Instance.touchdBuild);
    }


    /// <summary>
    /// Método que permite cambiar por medio de un botton la scena 
    /// </summary>
    /// <param name="levelName">nombre de escena que queremos cargar.</param>
    public void CallChangeScene(string levelName)
    {
        ScenesManager.Instance.isLoad = true;
        ScenesManager.Instance.LoadLevel(levelName);
    }

    /// <summary>
    /// Método que permite por medio de un botton salir del juego.
    /// </summary>
    public void CallQuit()
    {
        ScenesManager.Instance.Quit();
    }
}
