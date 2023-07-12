using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer GameAudioMixer;

    public void SetVolumeMusic(float slidervolume)
    {
        GameAudioMixer.SetFloat("MusicVolume", Mathf.Log10(slidervolume) * 20);
    }

    public void SetVolumeSFX(float slidervolume)
    {
        GameAudioMixer.SetFloat("SoundEffectVolume", Mathf.Log10(slidervolume) * 20);
    }
}
