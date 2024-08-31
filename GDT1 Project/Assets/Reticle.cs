using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;

        transform.position = mousePosition;
    }
}
