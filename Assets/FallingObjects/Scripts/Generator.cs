using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

public class Generator : MonoBehaviour
{
    public List<PrefabData> prefabs2;

    public float interval = 1f;
    void Start()
    {
        //InvokeRepeating("Generate", 5f, 1f);
        StartCoroutine(GenerateRoutine());

    }

    private IEnumerator GenerateRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(interval);
            Generate();
        }
    }

    private void Generate()
    {
        var obj = Instantiate(
            GetRandomPrefab(),
            transform
            );

        obj.transform.localPosition = new Vector3(
            Random.Range(-3f,3f),
            10,
            0
            );
        Destroy(obj.gameObject, 5f);
    }

    private FallingObject GetRandomPrefab()
    {
        float sum = 0f;
        float maxProb = prefabs2.Sum(p => p.probability);
        float r = Random.Range(0f, maxProb);

        for (int i = 0; i < prefabs2.Count; i++)
        {
            sum += prefabs2[i].probability;
            if(r <= sum) { return prefabs2[i].prefab; }
        }
        return prefabs2[0].prefab;
    }
}
