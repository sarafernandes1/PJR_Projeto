using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVida : MonoBehaviour
{
    int vida = 20;

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
        Destroy(this.gameObject);
    }
}
