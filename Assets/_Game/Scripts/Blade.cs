using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    private CircleCollider2D circleCollider2D;

    private Vector2 previousPosition;

    [SerializeField] private float minCutVelocity = 0.001f;

    private void Awake() {
        trailRenderer = this.gameObject.GetComponent<TrailRenderer>();
        circleCollider2D = this.gameObject.GetComponent<CircleCollider2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        trailRenderer.enabled = false;
        circleCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CutSystem();
    }

    private void CutSystem(){
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
            UpdateCut();
        }else if (Input.touchCount == 0){
            StopCut(); 
        }
    }

    private void UpdateCut(){
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        this.transform.position = newPosition;
        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;

        if(velocity > minCutVelocity){
            circleCollider2D.enabled = true;
            trailRenderer.enabled = true;

        }else{
            circleCollider2D.enabled = false;
            trailRenderer.enabled = false;
        }
    }
    private void StopCut(){
        if(this.transform.position == null){
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }

            circleCollider2D.enabled = false;
            trailRenderer.enabled = false;        
    }
}
