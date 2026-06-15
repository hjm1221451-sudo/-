using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public int speed;
    public float rotateSpeed;

    void Update()
    {
        StoneMove();
    }

    void StoneMove()
    {
        this.transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime);
        this.transform.Translate(Vector3.down * speed * Time.deltaTime,Space.World);

        if (this.transform.position.y < -2)
        {
            Destroy(this.gameObject);
        }
    }
}
