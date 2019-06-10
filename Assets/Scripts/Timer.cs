using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour{

    public float maxTime = 60.0f;

    private float countDown = 0.0f;

    // Start is called before the first frame update
    void Start(){
        this.countDown = this.maxTime;
    }

    // Update is called once per frame
    void Update(){
        this.countDown -= Time.deltaTime;
        if(this.countDown <= 0){
            Coin.coinsCount = 0;
            Application.LoadLevel(Application.loadedLevel);
            Debug.Log("El juego ha terminado, haz perdido");
        }
    }

}
