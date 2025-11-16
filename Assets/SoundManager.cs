using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using System.Linq;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    
    [SerializeField] private SoundEffect[] serializedSoundEffects;
    [SerializeField] private AudioSource soundEffectsSource;
    [SerializeField] private AudioSource musicSource;
    
    private const float SFX_VOLUME = 0.5f;

    private Dictionary<SoundEffectType, SoundEffect> soundEffects = new();

    private void Awake() => Instance = this;

    private void Start()
    {
        soundEffectsSource.volume = SFX_VOLUME;
        
        // Populate SFX dictionary
        foreach (SoundEffect effect in serializedSoundEffects)
            soundEffects.Add(effect.soundType, effect);
    } 
    public static void PlaySoundEffect(SoundEffectType soundType, bool pitchVariation=true) => Instance._PlaySoundEffect(soundType, pitchVariation);


    private void _PlaySoundEffect(SoundEffectType soundType, bool doPitchVariation=true)
    {
        if (!soundEffects.TryGetValue(soundType, out SoundEffect effect)) return;

        // Generate a new audio source
        AudioSource newSource = CopyComponent(soundEffectsSource, gameObject);
        newSource.clip = effect.audioClip;
        newSource.volume = SFX_VOLUME * effect.masterLevel;
        if (doPitchVariation) newSource.pitch = UnityEngine.Random.Range(0.98f, 1.02f); // Where 1 is normal pitch
        newSource.reverbZoneMix = 0.15f;

        newSource.Play();
        StartCoroutine(KillAudioSourceWhenFinished(newSource));
    }

    IEnumerator KillAudioSourceWhenFinished(AudioSource source)
    {
        yield return new WaitUntil(() => !source || !source.isPlaying);
        if (source) Destroy(source);
    }

    private static T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy as T;
    }
}

public enum SoundEffectType
{
    BillowDown,
    BillowUp,
    ChooChoo,
    ClownHorn,
    FireActive,
    FireIgnites,
    FireWanes,
    GrannyCoffee,
    GrannyInteract,
    GuitarStrums,
    ItemDrop,
    ItemPickup,
    PlayerCoffee,
    PlayerJump,
    PlayerStep,
    Train,
    TrainHorn,
    TrainInsideTunnel
}

[Serializable]
public struct SoundEffect 
{
    public AudioClip audioClip;
    public SoundEffectType soundType;
    [Range(0, 1)] public float masterLevel;
}
