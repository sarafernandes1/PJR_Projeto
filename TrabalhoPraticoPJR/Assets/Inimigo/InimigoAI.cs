using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAI : MonoBehaviour
{
    Transform player;

    float speed = 1.5f;
    float cooldownataque = 1.5f;
    float timer_ataque = 0;
    float distanceToPlayer;
    bool atingido, pode_atacar = false;

    public Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 look = new Vector3(player.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(look);

        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < 0.7f)
        {
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

        if ((distanceToPlayer <= 6.0f && distanceToPlayer >= 0.7f) || atingido && distanceToPlayer >= 0.7f)
        {
            Perseguir();
        }
        else
        {
            if (distanceToPlayer > 6.0f)
            {
                Normal();
            }
        }

    }
    void Normal()
    {
        ModoNormal();
        transform.position += transform.forward * 0 * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Perseguir()
    {
        speed = 1.5f;
        ModoPerseguicao();
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void Ataque()
    {
        animator.SetBool("ataque", true);
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
        yield return new WaitForSeconds(0.5f);
        pode_atacar = true;
    }
    IEnumerator damage()
    {
        yield return new WaitForSeconds(0.5f);
    }

}
