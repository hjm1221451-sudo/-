using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Stones : MonoBehaviour
{
    public GameObject stoneObj;
    public Camera mainCamera;

    public float spawnInterval = 1f;
    public float spawnYOffset = 1f;

    private float timer;

    void Start()
    {
        if (mainCamera == null)
        {
            Debug.Log("未找到主相机");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    private void SpawnObject()
    {
        float randomR = Random.Range(1.3f, 1.8f);

        Vector3 screenLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 screenRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));
        Vector3 screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane));

        float randomX = Random.Range(screenLeft.x, screenRight.x);
        float spawnY = screenTop.y + spawnYOffset;
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        if (stoneObj != null)
        {
            GameObject newStone = Instantiate(stoneObj, spawnPosition, Quaternion.identity);
            newStone.transform.localScale = Vector3.one * randomR;
        }
        else
        {
            Debug.Log("stone对象为空");
        }
    }
}
