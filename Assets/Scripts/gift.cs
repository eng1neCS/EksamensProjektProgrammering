using UnityEngine;

public class gift : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player1") || other.CompareTag("player2"))
        {
            Debug.Log("død");
        }
    }
}
