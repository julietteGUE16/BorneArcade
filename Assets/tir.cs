using UnityEngine;

public class tir : MonoBehaviour
{

    public Vector2 mouvement;
    public GameObject projectilePrefab;
    public float tirSpeed = 10f;

    // Autres variables du script et méthodes...

    // Update is called once per frame

     public void SetDirection(Vector2 newDirection)
    {
        mouvement = newDirection.normalized;
    }
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = mouvement * tirSpeed;
       
    }
    void Update()
    {

        Destroy(gameObject, 1.1f);
    }


    
}