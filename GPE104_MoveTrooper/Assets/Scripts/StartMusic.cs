using UnityEngine;

public class StartMusic : MonoBehaviour
{

    private AudioSource music;
    private AudioClip background;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        background = GameManager.core.BackgroundMusic;
        music = this.GetComponent<AudioSource>();
        music.clip = background;
        music.loop = true;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
