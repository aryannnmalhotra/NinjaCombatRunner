using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaWeapons : MonoBehaviour
{
    public bool isKunai;
    public GameObject EnemyBlood;
    public GameObject EnemyBlood2;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BetaEnemy"))
        {
            if (isKunai)
            {
                var blood1 = Instantiate(EnemyBlood) as GameObject;
                blood1.transform.position = new Vector3(collision.gameObject.transform.position.x + 2.3f, -2.2f, 0);
                var blood2 = Instantiate(EnemyBlood2) as GameObject;
                blood2.transform.position = new Vector3(collision.gameObject.transform.position.x + 2.1f, -1.55f, 0);
                float newHealth = collision.gameObject.GetComponent<Enemy>().GetHealth();
                newHealth = Mathf.Clamp(newHealth - 100, 0, 100);
                if (newHealth == 0)
                {
                    UIManager.Score += 20;
                    for (int i = 0; i < EnemySpawn.BetaE.Count; i++)
                    {
                        if (collision.gameObject == EnemySpawn.BetaE[i])
                        {
                            EnemySpawn.BetaE.RemoveAt(i);
                        }
                    }
                }
                collision.gameObject.GetComponent<Enemy>().SetHealth(newHealth);
                Destroy(this.gameObject);
            }
            else
            {
                var blood1 = Instantiate(EnemyBlood) as GameObject;
                blood1.transform.position = new Vector3(collision.gameObject.transform.position.x + 2.3f, -2.2f, 0);
                float newHealth = collision.gameObject.GetComponent<Enemy>().GetHealth();
                newHealth = Mathf.Clamp(newHealth - 50, 0, 100);
                if (newHealth == 0)
                {
                    UIManager.Score += 20;
                    for (int i = 0; i < EnemySpawn.BetaE.Count; i++)
                    {
                        if (collision.gameObject == EnemySpawn.BetaE[i])
                        {
                            EnemySpawn.BetaE.RemoveAt(i);
                        }
                    }
                }
                collision.gameObject.GetComponent<Enemy>().SetHealth(newHealth);
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("AlphaEnemy"))
        {
            if (isKunai)
            {
                var blood1 = Instantiate(EnemyBlood) as GameObject;
                blood1.transform.position = new Vector3(collision.gameObject.transform.position.x + 2.3f, -2.2f, 0);
                var blood2 = Instantiate(EnemyBlood2) as GameObject;
                blood2.transform.position = new Vector3(collision.gameObject.transform.position.x + 2.1f, -1.55f, 0);
                float newHealth = collision.gameObject.GetComponent<Enemy>().GetHealth();
                newHealth = Mathf.Clamp(newHealth - 50, 0, 100);
                if (newHealth == 0)
                {
                    UIManager.Score += 40;
                    for (int i = 0; i < EnemySpawn.AlphaE.Count; i++)
                    {
                        if (collision.gameObject == EnemySpawn.AlphaE[i])
                        {
                            EnemySpawn.AlphaE.RemoveAt(i);
                        }
                    }
                }
                collision.gameObject.GetComponent<Enemy>().SetHealth(newHealth);
                Destroy(this.gameObject);
            }
            else
            {
                var blood1 = Instantiate(EnemyBlood) as GameObject;
                blood1.transform.position = new Vector3(collision.gameObject.transform.position.x + 2.3f, -2.2f, 0);
                float newHealth = collision.gameObject.GetComponent<Enemy>().GetHealth();
                newHealth = Mathf.Clamp(newHealth - 40, 0, 100);
                if (newHealth == 0)
                {
                    UIManager.Score += 40;
                    for (int i = 0; i < EnemySpawn.AlphaE.Count; i++)
                    {
                        if (collision.gameObject == EnemySpawn.AlphaE[i])
                        {
                            EnemySpawn.AlphaE.RemoveAt(i);
                        }
                    }
                }
                collision.gameObject.GetComponent<Enemy>().SetHealth(newHealth);
                Destroy(this.gameObject);
            }
        }
    }
    void Update()
    {
        this.gameObject.transform.position += new Vector3(14*Time.deltaTime,0,0);
    }
}
