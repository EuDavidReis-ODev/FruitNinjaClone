using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{

    public TMP_Text txtScore,txtHighScore;

    public Image[] imgLifes;
    public Button btPause,btResume,btMainMenu,btClosePauseMenu,btSound;

    public GameObject panelPause, panelGame, panelGameOver;

    private GameController gameController;


    private GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        gameController = FindObjectOfType<GameController>();
        gameData = FindAnyObjectByType<GameData>();

        txtHighScore.text = "Recorde: "+gameData.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPauseGame(){
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ButtonOnPauseGame(){
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void showPanelGameOver(){
        panelGameOver.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        txtHighScore.text = "Recorde: "+gameData.GetScore().ToString();

        gameController.GameOver();
    }

    public IEnumerator showBombPanelGameOver(){
        gameController.GameOver();
        panelGame.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        panelGameOver.gameObject.SetActive(true);
        txtHighScore.text = "Recorde: "+gameData.GetScore().ToString();


    }

    public void ButtonRestart(){
        panelGame.gameObject.SetActive(true);
        panelGameOver.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);

        for(int i = 0;i<imgLifes.Length;i++){
            imgLifes[i].color = gameController.whiteColor;
        }
        gameController.RestartGame();
    }

}
