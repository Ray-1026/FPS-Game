using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goblin : MonoBehaviour
{
    enum state
    {
        seePlayer = 20,
        attackPlayer = 3
    }
    Animator anim;
    Transform target;
    NavMeshAgent nav;

    [SerializeField]
    [Range(1, 10)]
    float damage = 5f;

    private int hp = 5;
    bool isDead = false;

    float workTime;
    [SerializeField]
    [Range(1, 10)]
    float attackSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("player").transform;
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            nav.isStopped = true;
            return;
        }

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance < (int)state.seePlayer)
        {
            nav.SetDestination(target.position);

            anim.SetBool("see", true);


            if (distance < (int)state.attackPlayer)
            {
                anim.SetBool("attack", true);
            }
            else
            {
                anim.SetBool("attack", false);
            }
        }
        else
        {
            nav.SetDestination(transform.position);

            anim.SetBool("see", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            hp--;
            //Debug.Log(hp);
            if (hp <= 0 && !isDead)
            {
                isDead = true;
                anim.SetTrigger("dead");
                ScoreBoard.score++;
                Destroy(gameObject, 2f);
            }
        }

        if (other.CompareTag("boundary"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth p = other.GetComponent<PlayerHealth>();

            if (p != null)
            {
                workTime += Time.deltaTime;

                if (workTime >= attackSpeed)
                {
                    workTime = 0;
                    p.TakeDamage(damage);
                }
            }
        }
    }
}
