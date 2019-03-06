using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject volumeSlider;
    public GameObject fullscreenCheck;
    public Dropdown graphicDropdown;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    private void Start()
    {
        resolutions =Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width==Screen.currentResolution.width && resolutions[i].height==Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        StartSetup();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("quality", graphicDropdown.value);
    }

    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
        if(isFull)
            PlayerPrefs.SetInt("fullscreen",1);
        else if(!isFull)
            PlayerPrefs.SetInt("fullscreen", 0);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolution", resolutionDropdown.value);
    }

    void StartSetup()
    {
        float volume = PlayerPrefs.GetFloat("volume");
        SetVolume(volume);
        volumeSlider.GetComponent<Slider>().value = volume;

        int fullscreen = PlayerPrefs.GetInt("fullscreen");
        bool isFull=true;
        if(fullscreen == 1 )
        {
            isFull = true;
        }else if(fullscreen==0)
        {
            isFull = false;
        }
        SetFullScreen(isFull);
        fullscreenCheck.GetComponent<Toggle>().isOn = isFull;

        int quality = PlayerPrefs.GetInt("quality");
        SetQuality(quality);
        graphicDropdown.value = quality;
        graphicDropdown.RefreshShownValue();


        int resolution = PlayerPrefs.GetInt("resolution");
        SetResolution(resolution);
        resolutionDropdown.value = resolution;
        resolutionDropdown.RefreshShownValue();
    }
}
