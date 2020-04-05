using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmo : MonoBehaviour
{
    private GameObject NinjaP;
    public GameObject NinjaBlood;
    public GameObject NinjaBlood2;
    public bool isRocket;
    private void Awake()
    {
        NinjaP = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isRocket)
            {
                var blood1 = Instantiate(NinjaBlood) as GameObject;
                blood1.transform.position = new Vector3(NinjaP.transform.position.x - 1.45f,-2.82f,0);
                var blood2 = Instantiate(NinjaBlood2) as GameObject;
                blood2.transform.position = new Vector3(NinjaP.transform.position.x - 1.2f, -2.2f, 0);
                Ninja.Health = Mathf.Clamp(Ninja.Health - 8, 0, 100);
                Destroy(this.gameObject);
            }
            else
            {
                var blood1 = Instantiate(NinjaBlood) as GameObject;
                blood1.transform.position = new Vector3(NinjaP.transform.position.x - 1.6f, -2.82f, 0);
                Ninja.Health = Mathf.Clamp(Ninja.Health - 4, 0, 100);
                Destroy(this.gameObject);
            }
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        this.gameObject.transform.position += new Vector3(-5*Time.deltaTime,0,0);
        if (NinjaP.transform.position.x - this.gameObject.transform.position.x > 3.5f)
           Destroy(this.gameObject);
    }
}
