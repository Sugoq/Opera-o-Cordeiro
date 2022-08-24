using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [PropertySpace(SpaceBefore = 0, SpaceAfter = 20), PropertyOrder(0)]
    [SerializeField] List<SFX> sounds = new();
    

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        SetSource();
    }

    private void Start()
    {
        foreach(SFX s in sounds)
        {
            if (s.playOnAwake)
                s.source.Play();
        }
    }
    
    private void SetSource()
    {
        foreach (SFX s in sounds)
        {
            GameObject g = new (s.clipName);
            Transform t = g.transform;
            t.SetParent(this.transform);
            g.AddComponent<AudioSource>();
            s.source = g.GetComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.pitch = s.pitch;

        }
    }
    public void Play(string name)
    {
        if(name == "")
        {
            print("Empty Name");
            Debug.LogWarning("Missing the Clip's name");
            return;
        }
        SFX sound = null;
        foreach(SFX s in sounds)
        {
            if (s.clipName == name)
            {
                sound = s;
            }
        }
        if (sound.clipName == null)
        {
            Debug.LogWarning("Could not find" + name);
            return;
        }

        if (sound.useRandomClip)
        {
            int randomClip = Random.Range(0, sound.clips.Count);
            sound.source.clip = sound.clips[randomClip];
        }
        sound.source.Play();
    }
    
    [PropertySpace(SpaceAfter = 10)][InfoBox("Audio Test (Only In-Game)")]
    
    [Button("Audio 1")]
    private void TestPlay1(string clipName)
    {
        Play(clipName);
    }

    [Button("Audio 2")]
    private void TestPlay2(string clipName)
    {
        Play(clipName);
    }

    [Button("Audio 3")]
    private void TestPlay3(string clipName)
    {
        Play(clipName);
    }






}
