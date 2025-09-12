using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnInimigo : MonoBehaviour
{
    public GameObject inimigoPrefab;
    public Transform inimigoPosition;
    private int randomspawn;

    void Start()
    {
        InvokeRepeating("SpawnInimigo", 5f, 5f);
    }

    void FixedUpdate()
    {

    }

    void SpawnInimigo()
    {
        randomspawn = Random.Range(1, 4);

        if (randomspawn == 1)
        {
            inimigoPosition.transform.position = new Vector3(28f, 1.5f, 28f);
        }
        else if (randomspawn == 2)
        {
            inimigoPosition.transform.position = new Vector3(-28f, 1.5f, 28f);
        }
        else if (randomspawn == 3)
        {
            inimigoPosition.transform.position = new Vector3(28f, 1.5f, -28f);
        }
        else if (randomspawn == 4)
        {
            inimigoPosition.transform.position = new Vector3(-28f, 1.5f, -28f);
        }
        // Cria um Bullet a partir de BulletPrefab
        var inimigo = (GameObject)Instantiate(inimigoPrefab, inimigoPosition.position, inimigoPosition.rotation);
    }
}
