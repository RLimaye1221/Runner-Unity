using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMover : MonoBehaviour{
    private bool cubeDirection = true;
    private float cubeTimer = 5.0f;
    public float cubeSpeed = 0.25f;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (cubeDirection == true){
            transform.Translate(0,0,cubeSpeed);
        }
        else{
            transform.Translate(0,0,-cubeSpeed);
        }
        cubeTimer = cubeTimer - Time.deltaTime;
        if (cubeTimer <= 0){
            cubeDirection = !cubeDirection;
            cubeTimer = 5.0f;
        }
    }
}
