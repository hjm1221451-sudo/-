using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hp : MonoBehaviour
{
    public int hp = 3;
    public ParticleSystem hitEffect;
    public Camera mainCamera;
    public float flickerDuration = 3f;
    public float flickerInterval = 0.1f;
    public float moveSpeed = 5f;
    public AudioClip hitSound;

    private bool isInvincible = false;
    private AudioSource audioSource;
    private Vector3 originalPosition;
    private MeshRenderer meshRenderer;
    private Collider colliderComponent;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        meshRenderer = GetComponent<MeshRenderer>();
        colliderComponent = GetComponent<Collider>();
        originalPosition = transform.position;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isInvincible) return;

        if (other.CompareTag("Stone"))
        {
            Destroy(other.gameObject);
            StartCoroutine(HitSequence());
        }
    }

    private IEnumerator HitSequence()
    {
        isInvincible = true;
        hp--;

        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        if (hp <= 0)
        {
            Score.instance.ResetScore();
            SceneManager.LoadScene("LoseScene");
            yield break;
        }

        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }

        Vector3 screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0, mainCamera.nearClipPlane));
        Vector3 startPosition = new Vector3(originalPosition.x, screenBottom.y, originalPosition.z);
        transform.position = startPosition;

        yield return StartCoroutine(MoveToOriginalPosition());

        yield return StartCoroutine(Flicker());

        isInvincible = false;
    }

    private IEnumerator MoveToOriginalPosition()
    {
        if (meshRenderer != null)
        {
            meshRenderer.enabled = true;
        }

        while (Vector3.Distance(transform.position, originalPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = originalPosition;
    }

    private IEnumerator Flicker()
    {
        float elapsedTime = 0f;

        while (elapsedTime < flickerDuration)
        {
            if (meshRenderer != null)
            {
                meshRenderer.enabled = !meshRenderer.enabled;
            }

            elapsedTime += flickerInterval;
            yield return new WaitForSeconds(flickerInterval);
        }

        if (meshRenderer != null)
        {
            meshRenderer.enabled = true;
        }
    }
}
