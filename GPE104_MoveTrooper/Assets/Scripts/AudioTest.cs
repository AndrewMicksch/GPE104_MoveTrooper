using UnityEngine;

public class AudioTest : MonoBehaviour
{

    public AudioSource collideSFX;
    public AudioClip collideClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collideSFX.volume = 1.0f;
        collideSFX.clip = collideClip;
        collideSFX.PlayOneShot(collideClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
