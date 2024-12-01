using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    public float jumpForce;
    private int coins;
    public TextMeshProUGUI txtCoin;
    public GameObject doorway; 
    public AudioClip coinsound;
    AudioSource audioSource;
    // private int deaths;
    
    void Start(){
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal,0, moveVertical);

        rb.AddForce(movement * speed);
        
        if (Input.GetKeyDown("space")){
            rb.AddForce(0,100,0);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(coinsound, 0.8F);
            coins = coins + 1;
            txtCoin.text = "Coins: " + coins.ToString();
        }
        if (coins>= 10){
            GameObject.Destroy(doorway);
        }
        if(other.gameObject.CompareTag("LevelEnd")){
            SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
        }
        /*
        if(other.gameObject.CompareTag("Pickup")){
            audioSource.PlayOneShot(, 0.8F);
            deaths = deaths + 1;
            txtCoin.text = "Coins: " + coins.ToString();
        }
        if (coins>= 10){
            GameObject.Destroy(doorway);
        }
        */

    }
}