using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject splash;

    [HideInInspector] public Color32 pearColor = new Color32(174,185,0,255);
    [HideInInspector] public Color32 appleColor = new Color32(115,143,11,255);
    [HideInInspector] public Color32 coconutColor = new Color32(134,87,56,255);
    [HideInInspector] public Color32 pineappleColor = new Color32(202,111,26,255);
    [HideInInspector] public Color32 orangeColor = new Color32(253,122,10,255);
    
    private UIController uIController;

    [HideInInspector] public int score;

    // Start is called before the first frame update
    void Start()
    {
        uIController = FindAnyObjectByType<UIController>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        uIController.txtScore.text = "Score: "+ score;
    }
}
