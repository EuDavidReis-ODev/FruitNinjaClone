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

    public GameObject panelPause, panelGame;


    // Start is called before the first frame update
    void Start()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
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
}
