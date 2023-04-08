using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{   
    [SerializeField] private GameObject beanLight;
    [SerializeField] private float speed,startForce;

    private GameController gameController;

    private Rigidbody2D rb;

    private AudioController audioController;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        audioController = FindObjectOfType<AudioController>();
        gameController = FindObjectOfType<GameController>();
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate(){
        transform.Rotate(new Vector3(0f,speed,0f)*Time.deltaTime);
    }

        private void ApplyForce(){
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);

    }

    public void BombGameOver(){
        speed = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.simulated = false;
        CircleCollider2D collider = this.gameObject.GetComponent<CircleCollider2D>();
        collider.enabled = false;
        GameObject tempBeanLight = Instantiate(beanLight, this.transform.position, Quaternion.identity) as GameObject;
        tempBeanLight.transform.parent = gameController.allLightBeans;
        this.gameObject.GetComponent<AudioSource>().clip = audioController.bombExplodeAudio;
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
