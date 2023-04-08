using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private int highscore;
    private GameData gameData;
    public GameObject splash;

    public bool soundOnOff;

    [HideInInspector] public Color32 pearColor = new Color32(174,185,0,255);
    [HideInInspector] public Color32 appleColor = new Color32(115,143,11,255);
    [HideInInspector] public Color32 coconutColor = new Color32(134,87,56,255);
    [HideInInspector] public Color32 pineappleColor = new Color32(202,111,26,255);
    [HideInInspector] public Color32 orangeColor = new Color32(253,122,10,255);
    [HideInInspector] public Color32 redColor = new Color32(253,0,0,255);
    [HideInInspector] public Color32 whiteColor = new Color32(253,225,225,255);

    private UIController uIController;

    [HideInInspector] public int score,fruitsCount;

    [SerializeField] private GameObject fruitSpawner,blade,destroyer;

    public Transform allObjects,allSplashs,allSlicedFruits;

    // Start is called before the first frame update
    void Start()
    {
        uIController = FindAnyObjectByType<UIController>();
        gameData = FindAnyObjectByType<GameData>();
        highscore = gameData.GetScore();
        StartGame();
        Initialize();
        SoundsData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize(){
        int soundValue = gameData.GetSounds();
        if(soundValue == 1){
            soundOnOff = true;
            uIController.btSound.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = uIController.spriteSoundOn;

        }else {
            soundOnOff = false;
            uIController.btSound.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = uIController.spriteSoundOff;

        }
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

    public void GameOver(){
        fruitSpawner.gameObject.SetActive(false);
        blade.gameObject.SetActive(false);
        destroyer.gameObject.SetActive(false);

        if(score > highscore){
            gameData.SaveScore(score);
        }
    }

    public void RestartGame(){
        fruitSpawner.gameObject.SetActive(true);
        blade.gameObject.SetActive(true);
        destroyer.gameObject.SetActive(true);
        score = 0;
        fruitsCount = 0;
        uIController.txtScore.text = "Score: "+score.ToString();


    }

    public void SoundsData(){
        if(soundOnOff){
            gameData.SaveSounds(1);
            soundOnOff = true;
        }else{
            gameData.SaveSounds(0);
            soundOnOff = false;
        }
    }
}
