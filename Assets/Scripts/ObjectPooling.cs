using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    public int currentPool;
    public List<Pool> pools;
    [HideInInspector]
    public Queue<GameObject> objectPool = new Queue<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private IEnumerator Start()
    {
        yield return null;  

        for (int i = 0; i < pools[currentPool].size; i++)
        {
            GameObject objFromPool = Instantiate(pools[currentPool].prefab);
            objFromPool.SetActive(false);
            objectPool.Enqueue(objFromPool);
        }
    }

    public GameObject SpawnFromPool(Vector3 pos, Quaternion rot)
    {
        GameObject pipeToSpawn = objectPool.Dequeue();
        pipeToSpawn.SetActive(true);
        pipeToSpawn.transform.position = pos;
        pipeToSpawn.transform.rotation = rot;

        objectPool.Enqueue(pipeToSpawn);
        return pipeToSpawn;
    }
}

[System.Serializable]
public class Pool
{
    public GameObject prefab;
    public int size;
}
