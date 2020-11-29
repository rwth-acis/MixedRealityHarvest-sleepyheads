using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlacer : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 3f, layerMask))
        {
            transform.position = hit.point;
        }
    }
}
