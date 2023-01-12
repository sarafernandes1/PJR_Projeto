using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Posicionar : MonoBehaviour
{
    public List<Vector3> posicoes_validas;
    public Vector3[] posicaoinicial ;

    public int x = 10;
    public int z = 10;
    public LayerMask layerMask;
    public GameObject obj, inimigo_obj, player_obj, chave_obj;
    public float timer = 10;
    int numero_chaves = 5;

    void Start()
    {
        int i = PhotonNetwork.LocalPlayer.ActorNumber;
        CriarGrid(i-1);
        PosicionarJogadorInimigo();
    }

    void CriarGrid(int player)
    {
        posicoes_validas = new List<Vector3>();

        for (float i = posicaoinicial[player].x; i < x + posicaoinicial[player].x; i += 0.5f)
        {
            for (float j = posicaoinicial[player].z; j < z + posicaoinicial[player].z; j += 0.5f)
            {
                Vector3 pos = new Vector3(i, 1.0f, j - 0.5f);
                Vector3 pos1 = new Vector3(i, 0.0f, j - 0.5f);
                bool walkable = !(Physics.CheckSphere(pos1, 0.3f, layerMask));
                if (walkable)
                {
                    //var objeto = Instantiate(obj, pos1, Quaternion.identity);
                    posicoes_validas.Add(pos);
                }

            }
        }

    }

    public void Update()
    {
        if (timer == 10 && numero_chaves > 0)
        {
            int random = Random.Range(0, posicoes_validas.Count);
            Vector3 pos = new Vector3(posicoes_validas[random].x, 0.5f, posicoes_validas[random].z);
            PhotonNetwork.Instantiate("Chave", pos, Quaternion.identity);
            numero_chaves -= 1;
        }

        timer -= Time.deltaTime;
        if (timer <= 0) timer = 10;
    }

    public Vector3 JogadorSpawn()
    {
        int random1 = Random.Range(0, posicoes_validas.Count);
        return posicoes_validas[random1];
    }

    void PosicionarJogadorInimigo()
    {
        int random = Random.Range(0, posicoes_validas.Count);
        int i = 0;
        while (i < 3)
        {
            PhotonNetwork.Instantiate("Inimigo", posicoes_validas[random], Quaternion.Euler(0f, 0f, 0f));
            random = Random.Range(0 + i, posicoes_validas.Count - i);
            i++;
        }
        int random1 = Random.Range(0+i, posicoes_validas.Count-i);
        if (random1 != random)
        {
            PhotonNetwork.Instantiate("Player", posicoes_validas[random1], Quaternion.Euler(0f, 0f, 0f));
        }
    }
}
