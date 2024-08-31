using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Spellbolt;
    public Transform Wand;
    public float bulletSpeed = 50;

    Vector2 lookDirection;
    float lookAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        Wand.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject spellboltClone = Instantiate(Spellbolt);
            spellboltClone.transform.position = Wand.position;
            spellboltClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            spellboltClone.GetComponent<Rigidbody2D>().velocity = Wand.right * bulletSpeed;
        }
    }
}
