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
    [HideInInspector] public Color32 redColor = new Color32(253,0,0,255);
    
    private UIController uIController;

    [HideInInspector] public int score,fruitsCount;


    // Start is called before the first frame update
    void Start()
    {
        uIController = FindAnyObjectByType<UIController>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        score = 0;
        fruitsCount = 0;
        uIController.txtScore.text = "Score: "+ score.ToString();
    }

    public void updateScore(int points){
        score += points;
        uIController.txtScore.text = "Score: "+score.ToString();
    }
}
