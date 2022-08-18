using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("vol", vol);
    }

    public void SetGraphics(int graphicsDropdownIndex)
    {
        QualitySettings.SetQualityLevel(graphicsDropdownIndex); 
    }

    public void SetFullscreen (bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
}
