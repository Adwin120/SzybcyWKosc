using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncMusicVolume : MonoBehaviour
{
    // Start is called before the first frame update

    public GameSettings settings;

    private AudioSource source;
    void Start()
    {
        source = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        source.volume = settings.volume;
    }
}
