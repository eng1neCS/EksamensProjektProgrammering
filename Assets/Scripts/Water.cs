using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{

    private bool player2cooked = false;
    [SerializeField] private string level;
    [SerializeField] private string playerID;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<MovementScript>().PlayerID == playerID)
            {
                Debug.Log(playerID + " is dead ");
                player2cooked = true;
            }
            

        }
        isCooked2();
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<MovementScript>().PlayerID == playerID)
            {
                Debug.Log(playerID + " is dead ");
                player2cooked = true;
            }

        }

    }



    void isCooked2()
    {

        if (player2cooked)

        {
            SceneManager.LoadScene(level);
        }


    }








}