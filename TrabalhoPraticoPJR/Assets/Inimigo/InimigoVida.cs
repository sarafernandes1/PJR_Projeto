using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    int vida = 20;
    public GameObject chave;

    void Start()
    {
        
    }


    void Update()
    {
        if (vida == 0)
        {
            Morte();
        }
    }

    void Morte()
    {
        var obj = Instantiate(chave, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
