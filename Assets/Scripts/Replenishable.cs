using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replenishable : MonoBehaviour
{
    public bool isHealth;
    public bool isStar;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isHealth)
            {
                int toAdd = Random.Range(25,61);
                Ninja.Health = Mathf.Clamp(Ninja.Health + toAdd, 0, 100);
                for(int i = 0; i < ReplenishableSpawn.replenishables.Count; i++)
                {
                    if (ReplenishableSpawn.replenishables[i] == this.gameObject)
                    {
                        ReplenishableSpawn.replenishables.RemoveAt(i);
                        Destroy(this.gameObject);
                    }
                }
            }
            else if (isStar)
            {
                int toAdd = Random.Range(5, 11);
                Ninja.StarCount = Mathf.Clamp(Ninja.StarCount + toAdd, 0, 30);
                for (int i = 0; i < ReplenishableSpawn.replenishables.Count; i++)
                {
                    if (ReplenishableSpawn.replenishables[i] == this.gameObject)
                    {
                        ReplenishableSpawn.replenishables.RemoveAt(i);
                        Destroy(this.gameObject);
                    }
                }
            }
            else
            {
                int toAdd = Random.Range(5, 11);
                Ninja.KunaiCount = Mathf.Clamp(Ninja.KunaiCount + toAdd, 0, 20);
                for (int i = 0; i < ReplenishableSpawn.replenishables.Count; i++)
                {
                    if (ReplenishableSpawn.replenishables[i] == this.gameObject)
                    {
                        ReplenishableSpawn.replenishables.RemoveAt(i);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
    void Update()
    {
        
    }
}
