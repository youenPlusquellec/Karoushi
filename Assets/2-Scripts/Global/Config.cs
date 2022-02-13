using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class which contains game configuration
/// </summary>
[CreateAssetMenu(fileName = "Config", menuName = "Config", order = 1)]
public class Config : ScriptableObject
{
    [Header("Volume configuration")]
    [Range(0, 100)] 
    public float GameVolume = 100;

    [Range(0, 100)] 
    public float GameSoundEffectsVolume = 100;

    [Header("Mouse configuration")]
    [Range(0.1f, 5)]
    public float MouseSensibility = 1.0f;
    public bool MouseHorizontalInversion = false; // true : inverted
    public bool MouseVerticalInversion = false; // true : inverted

}
