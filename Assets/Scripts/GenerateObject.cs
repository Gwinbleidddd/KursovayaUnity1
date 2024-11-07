using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.UI;

public class GenerateObject : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text pointsText;
    int points = 0;
    Random rnd = new Random();
    private int height;
    [SerializeField] float MaxD = 0;
    [SerializeField] float D = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            points++;
            pointsText.text = "Points: " + points;

        }
    }

    void rHeight()
    {
        height = rnd.Next(1,3);
    }

    void pereprig()
    {
        if ((GameObject.FindGameObjectWithTag("Enemy Body").transform.position.z + 1) < (transform.position.z))
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy Body"));
            points++;
            pointsText.text = "Points: " + points;
        }
    }
    
    
    void Update()
    {
        D = transform.position.z;
        if (D - MaxD > 8 && D+5<100)
        {
            var cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            rHeight();
            cube1.transform.position = new Vector3(0, height, D+5);
            cube1.tag = "Enemy Body";
            MaxD = D;
        }
        pereprig();
    }
    
        
}

