using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    GameObject projectile;
    public GameObject projectilePrefab;
    public Vector2 playerMovement;
    public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EffectuerTir()
    {
        // Créer le projectile
        

         projectile = Instantiate(projectilePrefab, spawn.position, spawn.rotation);
        

        projectilePrefab.GetComponent<tir>().mouvement = playerMovement;


       
         //projectile.GetComponent<tir>().mouvement = playerMovement;

        // Ajouter une force au projectile pour le faire avancer
       
        
        
       
    }
}