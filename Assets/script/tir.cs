using UnityEngine;

public class tir : MonoBehaviour
{

    public Vector2 mouvement;
    public GameObject projectilePrefab;
    public float tirSpeed = 10f;

    // Autres variables du script et méthodes...

    // Update is called once per frame

    
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
            Debug.Log("player "+collision.gameObject.GetComponent<Player>().playerNumber +" : "+  collision.gameObject.GetComponent<Player>().life);
            Debug.Log("hit");
            collision.gameObject.GetComponent<Player>().life -= 1;
            collision.gameObject.GetComponent<Player>().spriteRendererLooseLife.GetComponent<SpriteRenderer>().enabled = true;
            collision.gameObject.GetComponent<Player>().StartCoroutine(collision.gameObject.GetComponent<Player>().waitLooseLife());
            Destroy(gameObject);
        }
    }


    
}