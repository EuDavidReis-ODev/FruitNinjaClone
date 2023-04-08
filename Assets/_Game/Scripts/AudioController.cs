using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource music,blade;
    public AudioClip[] bladeAudio,fruitSplashAudio;

    [SerializeField] AudioSource[] audioSources;
    public AudioClip bombExplodeAudio;

    [SerializeField] private float musicVolume, soundsVolume;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindAnyObjectByType<GameController>();
        EnableDisableSounds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableDisableSounds(){
        if(gameController.soundOnOff){
            audioSources[0].volume = musicVolume;
            for(int i = 1;i < audioSources.Length;i++){
                audioSources[i].volume = soundsVolume;
            }
        }else{
            
            for(int i = 0;i < audioSources.Length;i++){
                audioSources[i].volume = 0f;
            }

            foreach (Transform child in gameController.allObjects){
                    child.gameObject.GetComponent<AudioSource>().volume = 0f;
            }
        }
    }
}
