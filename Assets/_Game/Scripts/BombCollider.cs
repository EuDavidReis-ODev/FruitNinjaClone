using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollider : MonoBehaviour
{
    private Bomb bomb;
    // Start is called before the first frame update
    void Start()
    {
        bomb = this.gameObject.GetComponent<Bomb>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Blade")){
            bomb.BombGameOver();
        }
    }
}
