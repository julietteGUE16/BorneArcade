using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setScore : MonoBehaviour
{
    GameObject scoreText;
    public GameObject scoreTextPrefab;
    public Transform spawn;
    public GameObject parent;
    int poistionDépartY = 130;
    // Start is called before the first frame update
    void Start()
    {
        /*Debug.Log("part1");
        //scoreText = Instantiate(scoreTextPrefab, spawn.position, spawn.rotation);
        scoreText = Instantiate(scoreTextPrefab, parent.transform);

        Vector3 newPosition = objTransform.position + new Vector3(0f, poistionDépartY, 0f);
        objTransform.position = newPosition;
        Debug.Log("part2");*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
