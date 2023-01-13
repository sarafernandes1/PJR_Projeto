using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoAI : MonoBehaviour
{
    Transform player;

    float speed = 1.5f;
    float cooldownataque = 1.5f;
    float timer_ataque = 0;
    public float distanceToPlayer;
    bool atingido, pode_atacar = false;

    public Animator animator;
    public NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 look = new Vector3(player.position.x, transform.position.y, player.transform.position.z);
        //transform.LookAt(look);

        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer < 3.0f)
        {
            transform.LookAt(look);
            agent.Stop();
            ModoCombate();

            if (Time.time > timer_ataque)
            {
                animator.SetBool("ataque", true);
                StartCoroutine(ataque());
                if (pode_atacar)
                {
                    Ataque();
                }
            }
            else
            {
                pode_atacar = false;
                animator.SetBool("ataque", false);
            }
        }

        if (distanceToPlayer <=12.0f && distanceToPlayer >= 3.0f)
        {
            agent.Resume();
            Perseguir();
        }
        else
        {
            if (distanceToPlayer > 12.0f)
            {
                Normal();
            }
        }

    }
    void Normal()
    {
        ModoNormal();
        agent.Stop();
        transform.position += transform.forward * 0 * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Perseguir()
    {
        speed = 1.5f;
        ModoPerseguicao();

        agent.SetDestination(player.transform.position);
        //transform.position += transform.forward * speed * Time.deltaTime;
    }

    void Ataque()
    {
        animator.SetBool("ataque", true);
        StartCoroutine(damage());
        speed = 0.0f;
        timer_ataque = Time.time + cooldownataque;
    }

    void ModoCombate()
    {
        animator.SetBool("correr", false);
        animator.SetBool("combate", true);
    }

    void ModoPerseguicao()
    {
        animator.SetBool("combate", false);
        animator.SetBool("ataque", false);
        animator.SetBool("correr", true);
        animator.SetBool("idle", false);
    }

    void ModoNormal()
    {
        animator.SetBool("combate", false);
        animator.SetBool("ataque", false);
        animator.SetBool("correr", false);
        animator.SetBool("idle", true);
    }

    IEnumerator ataque()
    {
        yield return new WaitForSeconds(1.0f);
        pode_atacar = true;
    }
    IEnumerator damage()
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<JogadorVidas>().TirarVida();
    }

}
