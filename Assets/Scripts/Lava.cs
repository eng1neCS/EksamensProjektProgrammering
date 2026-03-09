using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{

    private bool player1cooked = false;
    [SerializeField] private string level;
    [SerializeField] private string playerID;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<MovementScript>().PlayerID == playerID)
            {
                Debug.Log(playerID + " is dead ");
                player1cooked = true;
            }


        }
        isCooked();
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<MovementScript>().PlayerID == playerID)
            {
                Debug.Log(playerID + " is dead ");
                player1cooked = true;
            }

        }

    }



    void isCooked()
    {

        if (player1cooked)

        {
            SceneManager.LoadScene(level);
        }


    }
}
