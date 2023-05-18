using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeInit : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    void Start()
    {
        var volumeValue = PlayerPrefs.GetFloat(volumeParameter, volumeParameter == "SoundtrackVolume" ? 0f : -80f);
        mixer.SetFloat(volumeParameter, volumeValue);
    }
}
