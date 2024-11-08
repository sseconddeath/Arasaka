using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject pl;
    public GameObject task;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(pl.CompareTag("Player"))
        {
            task.GetComponent<TaskMAnager>().tasks += 1;
        }
    }

}
