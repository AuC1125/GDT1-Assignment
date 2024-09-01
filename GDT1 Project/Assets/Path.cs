using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private int index = 0;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform [] WayPoints;
    [SerializeField] float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(index < 5){
            enemy.transform.Translate((WayPoints[index].position - enemy.transform.position).normalized * Time.deltaTime * speed);
            if (Vector3.Distance(WayPoints[index].position, enemy.transform.position) < 0.1f)
            {
                index++;
            }
        }
    }
}
