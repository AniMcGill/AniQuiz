using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

    public enum SeekDirection { Forward, Backward }

    public AudioSource source;
    public Text output;

    [SerializeField]
    [HideInInspector]
    private int currentIndex = 0;

    List<AudioClip> clips = new List<AudioClip>();
    Object[] myMusic;

    void Start() {
        if (source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
        LoadSounds("Competition");
	}

    public void Seek(bool dir)
    {
        SeekDirection d = SeekDirection.Forward;
        if (dir == true)
        { d = SeekDirection.Forward; } else if (dir == false) { d = SeekDirection.Backward; }

        if (d == SeekDirection.Forward)
        { 
            currentIndex = currentIndex + 1;
            if (currentIndex == clips.Count) currentIndex = 0;
        }
        else
        {
            currentIndex--;
            if (currentIndex < 0) currentIndex = clips.Count - 1;
        }
    }

    public void PlayCurrent()
    {
        source.clip = clips[currentIndex];
        if (!output.text.Contains(source.clip.name))
        {
            output.text += System.Environment.NewLine + source.clip.name;
        }
        source.Play();
    }

    public void LoadSounds(string group)
    {
        output.text = group + ":";
        myMusic = Resources.LoadAll("Music/" + group, typeof(AudioClip));
        clips = myMusic.Select(i => i as AudioClip).ToList();
        currentIndex = 0;
    }

    public void ReturnToMain()
    {
        GameControl.control.LoadScene("menu");
    }
}
