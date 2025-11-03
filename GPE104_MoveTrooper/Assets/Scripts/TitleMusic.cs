using UnityEngine;
using UnityEngine.UIElements;

public class TitleMusic : MonoBehaviour
{

    private AudioSource music;
    private AudioClip title;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        title = GameManager.core.TitleMusic;
        music = this.GetComponent<AudioSource>();
        music.clip = title;
        music.loop = true;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
