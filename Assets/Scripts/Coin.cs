using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour{

    public static int coinsCount = 0;

    public AudioSource coinSound;

    public Renderer rend;

    // Start is called before the first frame update
    void Start(){
        //Debug.Log("Moneda Creada Saisfactoriamente");
        Coin.coinsCount++;
        coinSound = GetComponent<AudioSource>();
        //Debug.Log(Coin.coinsCount);

        rend = GetComponent<Renderer>();
        rend.enabled = true;

    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Player")){
            //Debgug.Log("He tocado la moneda");
            coinSound.Play();
            rend.enabled = false;
            Destroy(gameObject, coinSound.clip.length);
        }
    }

    private void OnDestroy(){
        Coin.coinsCount--;
        if(Coin.coinsCount<=0){
            Debug.Log("El juego ha terminado, haz ganado!");
            GameObject timer = GameObject.Find("GameTimer");
            Destroy(timer);
            GameObject[] fireworks = GameObject.FindGameObjectsWithTag("Firework");
            foreach(GameObject firework in fireworks){
                firework.GetComponent<AudioSource>().Play();
                firework.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
