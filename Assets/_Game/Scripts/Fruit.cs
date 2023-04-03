using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Rigidbody2D myRB;

    public GameObject SlicedFruit;

    [SerializeField] private float startForce;

    private GameController gameController;

    public int points;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    
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
    public Color changeSplashColor(GameObject GO){
        string cloneObjectName = GO.transform.name;
        Color32 defColor = new Color32(255,255,255,255);

        switch(cloneObjectName){
            case "Apple_G Complete(Clone)": return gameController.appleColor;
            case "Pineapple Complete(Clone)": return gameController.pineappleColor;
            case "Coconut Complete(Clone)": return gameController.coconutColor;
            case "Orange Complete(Clone)": return gameController.orangeColor;
            case "Pear Complete(Clone)": return gameController.pearColor;
        }

        return defColor;
    }
}
