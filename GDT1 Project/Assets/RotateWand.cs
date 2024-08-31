using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWand : MonoBehaviour
{
    public Transform Mage;
    public float wandDistance;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = Mage.position + Vector3.up * wandDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mage != null)
        {
            Vector3 magePosition = Camera.main.WorldToScreenPoint(Mage.position);
            magePosition = Input.mousePosition - magePosition;
            float angle = Mathf.Atan2(magePosition.y, magePosition.x) * Mathf.Rad2Deg;

            Vector3 relative = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * wandDistance;
            transform.position = Mage.position + relative;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            
        }
    }
}
