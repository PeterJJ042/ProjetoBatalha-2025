using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class moveNPC : MonoBehaviour
{
    public float visao = 20.0f;
    public Transform alvo;
    private NavMeshAgent agente;
    private Vector3 starter;

    private GameObject[] paredes;  // Array para armazenar os objetos com tag "Walls"
    private Vector3 destinoAtual;
    private bool indoParaParedes = true;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        alvo = GameObject.FindWithTag("Player").transform;
        starter = transform.position;

        // Pega todos os objetos com a tag "Walls"
        paredes = GameObject.FindGameObjectsWithTag("Walls");

        if (paredes.Length == 0)
        {
            Debug.LogWarning("Nenhum objeto com a tag 'Walls' encontrado!");
        }
        else
        {
            // Escolhe um objeto aleatório de paredes para o NPC andar até ele
            int indiceAleatorio = Random.Range(0, paredes.Length);
            destinoAtual = paredes[indiceAleatorio].transform.position;
        }
    }

    void Update()
    {
        float distanciaAlvo = Vector3.Distance(transform.position, alvo.position);

        if (distanciaAlvo <= visao)
        {
            // Alvo está na visão, persegue
            agente.isStopped = false;
            agente.SetDestination(alvo.position);
        }
        else
        {
            // Alvo fora da visão, anda entre starter e destinoAtual (objeto Walls)

            if (paredes.Length == 0)
            {
                // Se não tem paredes, apenas fica parado
                agente.isStopped = true;
                return;
            }

            // Se chegou perto do destinoAtual, alterna destino entre starter e destinoAtual
            if (!agente.pathPending && agente.remainingDistance <= agente.stoppingDistance)
            {
                if (indoParaParedes)
                {
                    // Vai voltar para starter
                    destinoAtual = starter;
                    indoParaParedes = false;
                }
                else
                {
                    // Vai para parede novamente
                    int indiceAleatorio = Random.Range(0, paredes.Length);
                    destinoAtual = paredes[indiceAleatorio].transform.position;
                    indoParaParedes = true;
                }
                agente.SetDestination(destinoAtual);
            }
            else if (agente.destination != destinoAtual)
            {
                // Se ainda não está indo para o destinoAtual, define
                agente.isStopped = false;
                agente.SetDestination(destinoAtual);
            }
        }
    }
}
