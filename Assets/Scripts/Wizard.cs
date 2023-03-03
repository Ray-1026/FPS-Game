using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Wizard : MonoBehaviour
{
    enum state
    {
        seePlayer = 20,
        attackPlayer = 5
    }
    Animator anim;
    Transform target;
    NavMeshAgent nav;

    [SerializeField]
    [Range(1, 15)]
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
                Hit();
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

    private void Hit()
    {
        float angle = 60, radius = 5;
        Vector3 attackDir = transform.position - target.position;
        float realAngle = Mathf.Acos(Vector3.Dot(attackDir.normalized, target.forward)) * Mathf.Rad2Deg;
        if (realAngle < angle * 0.5f && attackDir.sqrMagnitude < radius * radius)
        {
            PlayerHealth p = target.GetComponent<PlayerHealth>();

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
