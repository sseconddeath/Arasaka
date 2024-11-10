using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject pl;
    public GameObject task;
    public GameObject activEvent;
    public string type_Trigger;
    public int activ_trigger=0;
    public int current_task;
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
            activEvent.SetActive(true);
            activ_trigger = 1;
        }
    }

    private void Trigget_Type()
    {

    }
}
