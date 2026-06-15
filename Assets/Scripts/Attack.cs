using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public ParticleSystem Explosion;
    public int pointsPerKill = 20;
    public AudioClip destroySound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (Explosion != null)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
            }

            if (destroySound != null && audioSource != null)
            {
                audioSource.PlayOneShot(destroySound);
            }

            if (Score.instance != null)
            {
                Score.instance.AddScore(pointsPerKill);
            }
            
            Destroy(this.gameObject, 0.1f);
        }
    }
}
