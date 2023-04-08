using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitsPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float minDelay, maxDelay;

    private GameController gameController;

    public Coroutine spawnCoroutine;

    private void Awake() {
        gameController = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Spawn(){

        while(gameController.gameStart){
            float delay = Random.Range(minDelay,maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject fruitPrefab = Instantiate(fruitsPrefabs[Random.Range(0, fruitsPrefabs.Length)],spawnPoint.position, spawnPoint.rotation);
            fruitPrefab.transform.parent = gameController.allObjects;
            spawnPoint.gameObject.GetComponent<AudioSource>().Play();
            Destroy(fruitPrefab,5f);
        }
    }
}
