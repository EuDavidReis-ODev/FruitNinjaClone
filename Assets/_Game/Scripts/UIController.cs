using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{

    public TMP_Text txtScore,txtHighScore,txtHighScoreGameOVer,txtHighScoreMainMenu;

    public Image[] imgLifes;
    public Button btPause,btResume,btMainMenu,btClosePauseMenu,btSound,btSoundMainMenu;

    public GameObject panelPause, panelGame, panelGameOver, panelMainMenu;

    private GameController gameController;

    public Sprite spriteSoundOn,spriteSoundOff;

    private GameData gameData;

    private AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        gameController = FindObjectOfType<GameController>();
        gameData = FindObjectOfType<GameData>();
        audioController = FindObjectOfType<AudioController>();
        txtHighScore.text = "Recorde: "+gameData.GetScore().ToString();
        txtHighScoreMainMenu.text = "Recorde: "+gameData.GetScore().ToString();

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
        gameController.SoundsData();
    }

    public void showPanelGameOver(){
        panelGameOver.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        txtHighScore.text = "Recorde: "+gameData.GetScore().ToString();
        txtHighScoreGameOVer.text = "Recorde: "+gameData.GetScore().ToString();

        gameController.GameOver();
    }

    public void showBombPanelGameOver(){
        gameController.GameOver();
        panelGame.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(true);
        txtHighScore.text = "Recorde: "+gameData.GetScore().ToString();
        txtHighScoreGameOVer.text = "Recorde: "+gameData.GetScore().ToString();
    }

    public void ButtonRestart(){
        panelGame.gameObject.SetActive(true);
        panelGameOver.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(false);
        gameController.RestartGame();
        txtScore.text = "Score: "+gameController.score.ToString();

        for(int i = 0;i<imgLifes.Length;i++){
            imgLifes[i].color = gameController.whiteColor;
        }
    }

    public void ButtonSounds(){
        if(gameController.soundOnOff){
            gameController.soundOnOff = false;
            btSound.gameObject.GetComponent<Image>().sprite = spriteSoundOff;
            btSoundMainMenu.gameObject.GetComponent<Image>().sprite = spriteSoundOff;

            
        }else{
            gameController.soundOnOff = true;
            btSound.gameObject.GetComponent<Image>().sprite = spriteSoundOn;
            btSoundMainMenu.gameObject.GetComponent<Image>().sprite = spriteSoundOn;

        }

        audioController.EnableDisableSounds();
    }


    public void InitializeSoundConfig(){
        if(gameController.soundOnOff){
        }else{
            btSound.gameObject.GetComponent<Image>().sprite = spriteSoundOn;
        }
    }

    public void ButtonBackMainMenu(){
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        txtHighScoreMainMenu.text = "Recorde: "+gameData.GetScore().ToString();

        
        for(int i = 0;i<imgLifes.Length;i++){
            imgLifes[i].color = gameController.whiteColor;
        }
        gameController.BackMainMenu();
    }

    public void ButtonStartGame(){
        panelMainMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.RestartGame();
        txtScore.text = "Score: "+gameController.score.ToString();
    }

    public void ButtonCloseGame(){
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack",true);
    }

}
