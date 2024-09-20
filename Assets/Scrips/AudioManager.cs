using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioClip birdCollision;
    public AudioClip birdSelect;
    public AudioClip birdFlying;
    public AudioClip pigCollision;
    public AudioClip pigCollisionDead;
    public AudioClip woodCollision;
    public AudioClip woodDestroyed;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }
    public void PlayBirdCollison(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(birdCollision, position, 1f);
    }
    public void PlayBirdSelect(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(birdSelect, position, 1f);
    }
    public void PlayBirdFlying(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(birdFlying, position, 1f);
    }
    public void PlayPigCollision(Vector3 position)
    {
        // int index = Random.Range(0, pigCollision.Length);
        AudioSource.PlayClipAtPoint(pigCollision, position, 1f);
    }
    public void PlayPigDestroyed(Vector3 position)
    {
        // int index = Random.Range(0, pigCollision.Length);
        AudioSource.PlayClipAtPoint(pigCollisionDead, position, 1f);
    }
    public void PlayWoodCollision(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(woodCollision, position, .5f);
    }
    public void PlayWoodDestroyed(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(woodDestroyed, position, .5f);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
