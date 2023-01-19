using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoAI : MonoBehaviour
{
    Transform player;

    float cooldownataque = 1.5f;
    float timer_ataque = 0;
    float distanceToPlayer;
    bool pode_atacar = false, normal=true, combate=false;

    public Animator animator;
    public NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 look = new Vector3(player.position.x, transform.position.y, player.transform.position.z);
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        //Modo Normal
        if (normal)
        {
            Normal();
        }

        //Modo Perseguir
        if (distanceToPlayer <= 14.0f && distanceToPlayer >= 3.0f)
        {
            agent.Resume();
            normal = false;
            combate = false;
            Perseguir();
        }
        else
        {
            //Modo Normal
            if (distanceToPlayer > 14.0f)
            {
                normal = true;
                combate = false;
            }
        }

        //Modo Combate
        if (distanceToPlayer < 3.0f)
        {
            normal = false;
            transform.LookAt(look);
            agent.Stop();
            ModoCombate();

            if (Time.time > timer_ataque)
            {
                animator.SetBool("ataque", true);
                StartCoroutine(ataque());
                distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
                if (pode_atacar && distanceToPlayer<4.0f)
                {
                    //Modo Ataque
                    Ataque();
                }
                else
                {
                    pode_atacar = false;
                    animator.SetBool("ataque", false);
                    if (distanceToPlayer >= 4.0f)
                    {
                        Perseguir();
                    }
                }
            }
            else
            {
                StartCoroutine(desativarAtaque());
            }
        }
    }

    void Normal()
    {
        ModoNormal();
        agent.Stop();
    }

    void Perseguir()
    {
        ModoPerseguicao();
        agent.SetDestination(player.transform.position);
    }

    void Ataque()
    {
            StartCoroutine(damage());
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

    IEnumerator desativarAtaque()
    {
        yield return new WaitForSeconds(0.5f);
        pode_atacar = false;
        animator.SetBool("ataque", false);
    }

    IEnumerator damage()
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<JogadorVidas>().TirarVida();
    }

}
