using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
        //Variaveis globais
    private Rigidbody2D     playerRb;
    private SpriteRenderer  playerSprite;
    public  float           velocidade;
    public  float           velocidadeMax;
    public  float           velocidadeInicial;
    public  bool            flipX;
    
        // Start is called before the first frame update
    void Start(){
        
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();

    }

        // Update is called once per frame
    void Update(){
        float movX = Input.GetAxis("Horizontal");
        if(movX > 0){
            velocidade = movX*(velocidadeMax-velocidadeInicial) + velocidadeInicial;
            flipX = false;
            playerSprite.flipX = flipX;
        } else if(movX < 0){
            velocidade = movX*(velocidadeMax-velocidadeInicial) - velocidadeInicial;
            flipX = true;
            playerSprite.flipX = flipX;
        } else {
            velocidade = 0;
        }

       playerRb.velocity = new Vector2(velocidade, playerRb.velocity.y); //ou (velocidade, playerRb.velocity.y)

    }

    void OnCollisionEnter2D(Collision2D colisao) {
        //
    }

    void OnTriggerEnter2D(Collider2D colisao) {
        //
    }

}
