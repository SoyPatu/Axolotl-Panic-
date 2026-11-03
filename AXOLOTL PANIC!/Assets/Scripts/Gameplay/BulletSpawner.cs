
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Configuracion de las balas")]
    public List<GameObject> bulletPrefabs;
    public Transform[] spawnPoints;

    [Header("Tiempo entre disparos")]
    public float minTime = 0.5f;
    public float maxTime = 2f;

    private Coroutine spawnCoroutine;

    void Start()
    {
        if (bulletPrefabs == null)
        {
            Debug.LogError("Falta asignar el prefab de la bala.");
            return;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("Debes asignar al menos un punto de aparicion.");
            return;
        }

        minTime = Mathf.Max(0.05f, minTime);
        maxTime = Mathf.Max(minTime, maxTime);

        spawnCoroutine = StartCoroutine(SpawnContinuously());
    }


    IEnumerator SpawnContinuously()
    {
        while (true)
        {
            if (bulletPrefabs != null &&spawnPoints != null && spawnPoints.Length > 0)
            {
                int index = Random.Range(0, spawnPoints.Length);
                Transform spawn = spawnPoints[index];

                if (spawn != null && bulletPrefabs != null)
                {
                    GameObject bullet = Instantiate(bulletPrefabs[Random.Range(0, bulletPrefabs.Count)], spawn.position, spawn.rotation);

                    if (bullet != null)
                    {
                        BulletMovement movement =bullet.GetComponent<BulletMovement>();

                    }
                }
            }

            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

}
