using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealt : MonoBehaviour
{

    public Image healtBar;
    public float maxHealt = 100f;
    public float HP;
    
    // Start is called before the first frame update
    void Start()
    {
        healtBar = GetComponent<Image>();
        HP = maxHealt;
    }

    // Update is called once per frame
    void Update()
    {
        healtBar.fillAmount = HP / maxHealt;
    }
}
