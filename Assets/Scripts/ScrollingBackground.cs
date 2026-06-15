using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public float scrollHeight = 4.5f;
    public SpriteRenderer backgroundSprite;

    private Vector3 startPosition;
    private GameObject secondBackground;

    void Start()
    {
        startPosition = transform.position;
        
        if (backgroundSprite == null)
        {
            backgroundSprite = GetComponent<SpriteRenderer>();
        }
        
        CreateSecondBackground();
    }

    void CreateSecondBackground()
    {
        secondBackground = new GameObject("Background_Clone");
        secondBackground.transform.SetParent(transform.parent);
        secondBackground.transform.position = startPosition + Vector3.up * scrollHeight;
        secondBackground.transform.localScale = transform.localScale;
        
        SpriteRenderer cloneRenderer = secondBackground.AddComponent<SpriteRenderer>();
        cloneRenderer.sprite = backgroundSprite.sprite;
        cloneRenderer.color = backgroundSprite.color;
        cloneRenderer.sortingOrder = backgroundSprite.sortingOrder;
        cloneRenderer.sortingLayerID = backgroundSprite.sortingLayerID;
        cloneRenderer.flipX = backgroundSprite.flipX;
        cloneRenderer.flipY = backgroundSprite.flipY;
        cloneRenderer.size = backgroundSprite.size;
        cloneRenderer.drawMode = backgroundSprite.drawMode;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, scrollHeight);
        
        transform.position = startPosition + Vector3.down * newPosition;
        secondBackground.transform.position = startPosition + Vector3.up * (scrollHeight - newPosition);
    }

    public void SetScrollSpeed(float speed)
    {
        scrollSpeed = speed;
    }

    void OnDestroy()
    {
        if (secondBackground != null)
        {
            Destroy(secondBackground);
        }
    }
}
