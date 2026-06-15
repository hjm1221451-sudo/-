using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public int speed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stone"))
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        this.transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (this.transform.position.y > 6 )
        {
            Destroy(this.gameObject);
        }
    }
}
