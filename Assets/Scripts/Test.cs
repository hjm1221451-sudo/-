using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        this.transform.Rotate(Vector3.right, 20 * Time.deltaTime);
        this.transform.Translate(Vector3.down * Time.deltaTime);
    }
}
