using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private ScoreManager sm;
    public int IncrementScore = 1;
    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.name == "Player")
       {
           Debug.Log("Collided with Player");
           sm.AddToScore(IncrementScore);
           gameObject.SetActive(false) ;
       }
    }
}
