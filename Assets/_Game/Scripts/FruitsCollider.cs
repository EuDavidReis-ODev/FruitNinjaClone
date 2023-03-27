using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsCollider : MonoBehaviour
{
    private Fruit fruit;
    // Start is called before the first frame update
    void Start()
    {
        fruit = this.gameObject.GetComponent<Fruit>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Blade")){
            GameObject tempFruitSliced = Instantiate(fruit.SlicedFruit, transform.position, Quaternion.identity);
            tempFruitSliced.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(-tempFruitSliced.transform.GetChild(0).transform.right * Random.Range(5f,9f));
            tempFruitSliced.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().AddForce(tempFruitSliced.transform.GetChild(1).transform.right * Random.Range(5f,9f));
            Destroy(this.gameObject);

            Destroy(tempFruitSliced,5f);
        }
    }
}
