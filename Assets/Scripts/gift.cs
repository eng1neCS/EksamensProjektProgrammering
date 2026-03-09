using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class gift : MonoBehaviour
{
    [SerializeField] private string level;
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player1") || other.CompareTag("player2"))
        {
            SceneManager.LoadScene(level);
        }
    }
}
