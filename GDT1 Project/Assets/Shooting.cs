using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public GameObject Spellbolt;
    public Transform Wand;
    public float bulletSpeed = 50;
    private bool isFired;
    private PlayerActions fire;
    private InputAction fireAction;

    Vector2 lookDirection;
    float lookAngle;

    void Awake()
    {
        fire = new PlayerActions();
        fireAction = fire.fire.shoot;
        fireAction.started += Fire;
    }

    void OnEnable()
    {
        fire.Enable();
        
    }

    void OnDisable()
    {
        fire.Disable();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        isFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Fire (InputAction.CallbackContext context)
    {
        isFired = true;
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        Wand.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (isFired)
        {
            GameObject spellboltClone = Instantiate(Spellbolt);
            spellboltClone.transform.position = Wand.position;
            spellboltClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            spellboltClone.GetComponent<Rigidbody2D>().velocity = Wand.right * bulletSpeed;
            isFired = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ghoul"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
