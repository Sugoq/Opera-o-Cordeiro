using Sirenix.OdinInspector;
using UnityEngine;


[CreateAssetMenu(fileName = "Sound Effect", menuName = "SFXS/Sound", order = 1)]
public class SFX : ScriptableObject 
{
    
    public string clipName;
    public AudioClip clip;

    public bool loop;
    public bool playOnAwake;
    [DetailedInfoBox("Dont know what it is?", "Setting this as true will play the Sound when the game/gameObject is initialzed")]
    [Range(0f, 1f)]
    public float volume;
    [Range(-3f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
