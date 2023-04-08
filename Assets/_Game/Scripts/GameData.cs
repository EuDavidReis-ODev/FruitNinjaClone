using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScore(int score){
        PlayerPrefs.SetInt("highscore",score);

    }

    public int GetScore(){
        return PlayerPrefs.GetInt("highscore",0);
    }

    public void SaveSounds(int value){
        PlayerPrefs.SetInt("sounds",value);
    }

    public int GetSounds(){
        return PlayerPrefs.GetInt("sounds",1);
    }
}
