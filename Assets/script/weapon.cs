using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Ce script permet de tirer des projectiles
*/

public class Weapon : MonoBehaviour
{

    
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

    public void EffectuerTir(float scale)
    {
        // Créer le projectile
        

         GameObject projectile = Instantiate(projectilePrefab, spawn.position, spawn.rotation);
         projectile.transform.localScale = new Vector3(scale, scale, scale);
        

        projectilePrefab.GetComponent<Tir>().mouvement = playerMovement;
      
    }
}
