using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
           Debug.Log("Collided with Coin");
           sm.AddToScore(IncrementScore);
           gameObject.SetActive(false);

           if(gameObject.name == "Bomb")
           {
               Debug.Log("Collided with Bomb");
               SceneManager.LoadScene("Main");
           }
       }
    }
}
