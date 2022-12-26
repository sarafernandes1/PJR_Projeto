using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAI : MonoBehaviour
{
    GameObject player;

    float speed=3.0f;
    float cooldownataque = 2; 
    float timer_ataque = 0;
    float distanceToPlayer;
    bool atingido, pode_atacar = false;

    public Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        Vector3 look = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(look);

        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        Ray inimigo_ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * 6.0f));

        if (Physics.Raycast(inimigo_ray, 8.0f))
        {
            speed = 5.0f;
        }

        if (distanceToPlayer < 4.0f)
        {
            ModoCombate();
          
            if (Time.time > timer_ataque)
            {
                animator.SetBool("ataque", true);
                StartCoroutine(espera4());
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

        if ((distanceToPlayer <= 25.0f && distanceToPlayer >= 4.0f) || atingido && distanceToPlayer >= 4.0f)
        {
          
            Perseguir();
        }
        else
        {
            if (distanceToPlayer > 25.0f)
            {
                Normal();
            }
        }

    }

  
    IEnumerator damage()
    {
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator espera4()
    {
        yield return new WaitForSeconds(0.5f);
        pode_atacar = true;
    }

    void Ataque()
    {
        animator.SetBool("ataque", true);
        speed = 0.0f;
        timer_ataque = Time.time + cooldownataque;
    }

    void Perseguir()
    {
        speed = 3.0f;
        animator.SetBool("combate", false);
        animator.SetBool("ataque", false);
        animator.SetBool("correr", true);
        animator.SetBool("idle", false);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void ModoCombate()
    {
        animator.SetBool("correr", false);
        animator.SetBool("combate", true);
    }

    void Normal()
    {
        animator.SetBool("idle", true);
        animator.SetBool("correr", false);
        animator.SetBool("combate", false);
        animator.SetBool("ataque", false);
        transform.position += transform.forward * 0 * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }

}
