using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] float maxSearchDist;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        FindingPlayer();
    }

    void FindingPlayer()
    {
        RaycastHit hit;
        if(Vector3.Distance(transform.position, player.transform.position) < maxSearchDist )
        {
            Debug.Log("Within Distance");
            if(Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit, maxSearchDist))
            {
                Debug.Log("Searching");
                if(hit.transform.tag == "Player" && !GetComponent<EnemyBarks>().isBarking)
                {
                    GetComponent<EnemyBarks>().isBarking = true;
                    Debug.Log("You are seen!");
                    StartCoroutine(GetComponent<EnemyBarks>().BarkOrder());
                } else if (hit.transform.tag != "Player" && GetComponent<EnemyBarks>().isBarking){
                    GetComponent<EnemyBarks>().isBarking = false;
                    
                }                                  
            }
        }
    }
}
