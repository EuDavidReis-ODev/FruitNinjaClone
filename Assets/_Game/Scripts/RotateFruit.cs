using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFruit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateFruitSliced(Random.Range(350f,500f));
    }

    private void RotateFruitSliced(float speed){
        this.transform.GetChild(0).transform.Rotate(new Vector3(0f, speed, speed)*Time.deltaTime);
        this.transform.GetChild(1).transform.Rotate(new Vector3(0f, speed, speed)*Time.deltaTime);

    }
}
