using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsCollider : MonoBehaviour
{
    private Fruit fruit;
    private GameController gameController;

    private UIController uIController;

    private AudioController audioController;

    // Start is called before the first frame update
    void Start()
    {
        fruit = this.gameObject.GetComponent<Fruit>();
        gameController = FindObjectOfType<GameController>();
        uIController = FindObjectOfType<UIController>();
        audioController = FindObjectOfType<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Blade")){
            target.gameObject.GetComponent<AudioSource>().clip = audioController.bladeAudio[Random.Range(0,audioController.bladeAudio.Length)];
            target.gameObject.GetComponent<AudioSource>().Play();
            GameObject tempFruitSliced = Instantiate(fruit.SlicedFruit, transform.position, Quaternion.identity);
            GameObject tempSplash = Instantiate(gameController.splash,transform.position, Quaternion.identity);

            gameController.updateScore(this.gameObject.GetComponent<Fruit>().points);

            tempFruitSliced.transform.parent = gameController.allSlicedFruits;
            tempSplash.GetComponentInChildren<SpriteRenderer>().color = fruit.changeSplashColor(this.gameObject);
            tempSplash.transform.parent = gameController.allSplashs;
            tempFruitSliced.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(-tempFruitSliced.transform.GetChild(0).transform.right * Random.Range(5f,8f),ForceMode.Impulse);
            tempFruitSliced.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().AddForce(tempFruitSliced.transform.GetChild(1).transform.right * Random.Range(5f,8f),ForceMode.Impulse);
            tempFruitSliced.gameObject.GetComponent<AudioSource>().clip = audioController.fruitSplashAudio[Random.Range(0,audioController.fruitSplashAudio.Length)];
            tempFruitSliced.gameObject.GetComponent<AudioSource>().Play();
            Destroy(tempFruitSliced,5f);
            Destroy(tempSplash,Random.Range(3,6));
            Destroy(this.gameObject);

        }
        else if(target.gameObject.CompareTag("Destroyer")){
            gameController.fruitsCount++;
            uIController.imgLifes[gameController.fruitsCount-1].color = gameController.redColor;
            if(gameController.fruitsCount >= 3){
                uIController.showPanelGameOver();
            }
        }
    }
}
