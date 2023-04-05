using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitsPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float minDelay, maxDelay;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn(){

        while(true){
            float delay = Random.Range(minDelay,maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject fruitPrefab = Instantiate(fruitsPrefabs[Random.Range(0, fruitsPrefabs.Length)],spawnPoint.position, spawnPoint.rotation);
            spawnPoint.gameObject.GetComponent<AudioSource>().Play();
            Destroy(fruitPrefab,5f);
        }
    }
}
