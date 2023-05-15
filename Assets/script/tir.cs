using UnityEngine;

/*
Ce script permet de controler le tir du joueur
*/


public class Tir : MonoBehaviour
{

    public Vector2 mouvement;
    public GameObject projectilePrefab;
    float tirSpeed = 100f;

  
    
    void Start()
    {
        
       
        GetComponent<Rigidbody2D>().velocity = mouvement * tirSpeed;
       
    }
    void Update()
    {

        Destroy(gameObject, 1.1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);

        }else if(collision.gameObject.tag == "Player"){
            
            collision.gameObject.GetComponent<Player>().life -= 1;
            collision.gameObject.GetComponent<Player>().spriteRendererLooseLife.GetComponent<SpriteRenderer>().enabled = true;
            collision.gameObject.GetComponent<Player>().StartCoroutine(collision.gameObject.GetComponent<Player>().waitLooseLife());
            Destroy(gameObject);
        }
    }


    
}