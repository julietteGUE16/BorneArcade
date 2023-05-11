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
            collision.gameObject.GetComponent<Player>().life -= 1;
            Destroy(gameObject);
        }
    }


    
}