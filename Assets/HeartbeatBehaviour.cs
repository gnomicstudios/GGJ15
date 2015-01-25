using UnityEngine;
using System.Collections;

public class HeartbeatBehaviour : MonoBehaviour {

    public Health health;
    
    AudioSource[] heartBeatAudioSources;
    AudioSource currentAudioSource;

	// Use this for initialization
	void Start () 
    {
        var sounds = GetComponents<AudioSource>();
        heartBeatAudioSources = new AudioSource[sounds.Length];
        for(var i = 0; i < sounds.Length; i++)
        {
            heartBeatAudioSources[i] = sounds[i];
        }
	}
	
	void Update () 
    {
        var ratio = health.currentHealth / (float)health.maxHealth;
        var i = (int)(ratio * heartBeatAudioSources.Length);
        if (i == heartBeatAudioSources.Length)
            i--;

        if (currentAudioSource != heartBeatAudioSources[i])
        {
            if (currentAudioSource != null)
                currentAudioSource.Stop();
            currentAudioSource = heartBeatAudioSources[i];
            currentAudioSource.Play();
        }
	}
}
