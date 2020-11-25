using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFallCleaner : MonoBehaviour
{
    private BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(100, 0.4f, 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
