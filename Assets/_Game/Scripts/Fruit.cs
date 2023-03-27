using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Rigidbody2D myRB;

    public GameObject SlicedFruit;

    [SerializeField] private float startForce;
    // Start is called before the first frame update
    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ApplyForce(){
        myRB.AddForce(transform.up * startForce, ForceMode2D.Impulse);

    }
}
