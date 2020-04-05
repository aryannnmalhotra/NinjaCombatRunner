using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public bool isEnemyBlood;
    void Start()
    {
        Invoke("ToDestroy", 0.2f);
    }
    void ToDestroy()
    {
        Destroy(this.gameObject);
    }
    void Update()
    {
        if(!isEnemyBlood)
           this.gameObject.transform.position += new Vector3(3.5f*Time.deltaTime, 0, 0);
    }
}
