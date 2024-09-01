using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    

    //private Vector3 direction = new Vector3(0f,0f,1f);
    private PlayerActions actions;
    private InputAction movementAction;

    

    void Awake()
    {
        actions = new PlayerActions();
        movementAction = actions.walking.movement;
        
    }

    void OnEnable()
    {
        movementAction.Enable();
        
    }

    void OnDisable()
    {
        movementAction.Disable();
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = movementAction.ReadValue<Vector2>();
        Vector3 direction = new Vector3(move.x, move.y, 0f);
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
    }

}
