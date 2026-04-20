using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{

    private bool player1cooked = false;
    [SerializeField] private string level;
    [SerializeField] private string playerID;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MovementScript>().PlayerID == playerID)
        {
            SceneManager.LoadScene(level);
        }
    }
}
