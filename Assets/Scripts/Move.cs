using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speed = 2;
    public Camera mainCamera;

    private float screenLeft;
    private float screenRight;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        CalculateScreenBounds();
    }

    void CalculateScreenBounds()
    {
        Vector3 leftBound = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 rightBound = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));
        
        screenLeft = leftBound.x;
        screenRight = rightBound.x;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            float newPosition = currentPosition.x - speed * Time.deltaTime;
            if (newPosition >= screenLeft)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector3(screenLeft, currentPosition.y, currentPosition.z);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            float newPosition = currentPosition.x + speed * Time.deltaTime;
            if (newPosition <= screenRight)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector3(screenRight, currentPosition.y, currentPosition.z);
            }
        }
    }
}
