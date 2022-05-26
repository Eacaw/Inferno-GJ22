using UnityEngine;

public class CorpseSpawner : MonoBehaviour
{
    public GameObject corpsePrefab;

    void Start()
    {
        InvokeRepeating("SpawnCorpse", 0, 3.0f);
    }

    void SpawnCorpse()
    {
        float randomOffset = Random.Range(-1.0f, 1.0f);
        GameObject corpse =
            Instantiate(corpsePrefab,
                         transform.position + new Vector3(randomOffset, randomOffset, randomOffset),
                         transform.rotation);
        Destroy(corpse, 60.0f); // the 60f will delete the corpse after 60 seconds
    }
}