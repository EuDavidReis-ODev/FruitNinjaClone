using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsCollider : MonoBehaviour
{
    private Fruit fruit;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        fruit = this.gameObject.GetComponent<Fruit>();
        gameController = FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Blade")){
            GameObject tempFruitSliced = Instantiate(fruit.SlicedFruit, transform.position, Quaternion.identity);
            GameObject tempSplash = Instantiate(gameController.splash,transform.position, Quaternion.identity);

            gameController.updateScore(this.gameObject.GetComponent<Fruit>().points);

            tempSplash.GetComponentInChildren<SpriteRenderer>().color = fruit.changeSplashColor(this.gameObject);
            tempFruitSliced.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(-tempFruitSliced.transform.GetChild(0).transform.right * Random.Range(5f,8f),ForceMode.Impulse);
            tempFruitSliced.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().AddForce(tempFruitSliced.transform.GetChild(1).transform.right * Random.Range(5f,8f),ForceMode.Impulse);
            Destroy(tempFruitSliced,5f);
            Destroy(this.gameObject);

        }
    }
}
