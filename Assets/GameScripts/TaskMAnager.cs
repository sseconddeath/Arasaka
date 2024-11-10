using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMAnager : MonoBehaviour
{
    [SerializeField]
    GameObject[] triggers;
    public GameObject triggerActiv;

    [SerializeField, HideInInspector]
    int activeIndexTask = -1;

    GameObject player;
    public int tasks = 0;
    public int curret_trigger = 0;
   

    void Start()
    {
      
        
    }

    void Update()
    {
        if (curret_trigger != triggers.Length-1)
        {


            currenttrigger();
        }
    }

    void currenttrigger()
    {

            for (int i = curret_trigger; i < triggers.Length; i++)
            {
                if (curret_trigger == i && triggers[i].GetComponent<Trigger>().activ_trigger == 1 && triggers[i].GetComponent<Trigger>().current_task == tasks)
                {
                    triggers[i + 1].SetActive(true);
                    triggers[i].SetActive(false);

                    curret_trigger++;
                }

            }
        
        
    }



}
