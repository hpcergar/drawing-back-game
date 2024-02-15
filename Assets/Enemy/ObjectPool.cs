using System.Collections;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField][Range(0, 50)] int poolSize = 5;
    [SerializeField][Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(InstantiateEnemies());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for(int i = 0; i < poolSize; i++)
        {
            GameObject go = Instantiate(prefab, transform);
            go.SetActive(false);
            pool[i] = go;
        }
    }

    IEnumerator InstantiateEnemies()
    {
        while (true) {
            EnableNext();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    void EnableNext()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject go = pool[i];
            if (!go.activeInHierarchy) {
                go.SetActive(true);
                return;
            }
        }
    }
}
