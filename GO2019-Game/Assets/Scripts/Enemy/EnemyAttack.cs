using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerUIManager playerManager;
    public float damage;
    public float damageTimer;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUIManager>();
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            playerManager.TakeDamage(damage);
            StartCoroutine(ResetCollider());
        }
    }

    IEnumerator ResetCollider()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(damageTimer);
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        yield return null;
    }
}
