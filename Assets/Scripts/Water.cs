using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{

    private bool player2cooked = false;
    [SerializeField] private string level;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player2"))
        {

            player2cooked = true;

        }
        isCooked2();
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player2"))
        {

            player2cooked = false;

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