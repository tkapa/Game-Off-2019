using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;

    [SerializeField] private float maxSearchDist = 0;

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
            if(Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit, maxSearchDist))
            {
                if(hit.transform.tag == "Player" && !GetComponent<EnemyBarks>().isBarking)
                {
                    GetComponent<EnemyBarks>().isBarking = true;
                    StartCoroutine(GetComponent<EnemyBarks>().BarkOrder());
                } else if (hit.transform.tag != "Player" && GetComponent<EnemyBarks>().isBarking){
                    GetComponent<EnemyBarks>().isBarking = false;
                    
                }                                  
            }
        }
    }
}
