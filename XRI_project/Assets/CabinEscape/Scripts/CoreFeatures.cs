using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FeatureUsage
{
    Once, // use once
    Toggle // if we want ot use the features more than once
}

public class CoreFeatures : MonoBehaviour
{
    /**
     * We nedd a common way to access this code outside of this class
     * Create a property value - Encapsulation
     * Properties have ACCESSORS to basically define the properties
     * GET accessor (READ) return encapsulated variable
     * SET Accessor (WRITE) allocates new values to fields   
    **/

    public bool AudioSFXSourceCreate { get; set; }

    [field: SerializeField]

    public AudioClip AudioClipOnStart { get; set; }
    public AudioClip AudioClipOnEnd { get; set; }

    private AudioSource audioSource;

    public FeatureUsage featureUsage = FeatureUsage.Once;

    protected virtual void Awake()
    {
        MakeAudioSFXSource();
    }

    private void MakeAudioSFXSource()
    {
        audioSource = GetComponent<AudioSource>();

        // if this is equal to null, create it here

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Regardless of null or not, we still need to make sure this is true on Awake

        AudioSFXSourceCreate = true;
    }

    protected void PlayOnStart()
    {
        if (AudioSFXSourceCreate && AudioClipOnStart != null)
        {
            audioSource.clip = AudioClipOnStart;
            audioSource.Play();
        }
    }

    protected void PlayOnSEnd()
    {
        if (AudioSFXSourceCreate && AudioClipOnEnd != null)
        {
            audioSource.clip = AudioClipOnEnd;
            audioSource.Play();
        }
    }
}


