using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for collision with spellbolt
        if (collision.gameObject.CompareTag("Spellbolt"))
        {
            Destroy(gameObject); // Destroy the ghoul on collision
            Destroy(collision.gameObject); // Optionally destroy the spellbolt as well
        }
    }
}
