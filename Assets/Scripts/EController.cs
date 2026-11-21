using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    Animator anim;
    NavMeshAgent agent;
    public float attackRadious = 8;
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
     void Update()
    {
        float dist = Vector3.Distance(transform.position, Player.transform.position);
        if (dist < attackRadious)
        {
            agent.SetDestination(Player.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Reduce the health

            anim.SetTrigger("Die");
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
