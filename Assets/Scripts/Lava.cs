using UnityEngine;

public class Lava : MonoBehaviour
{

    private bool player1cooked = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player1"))
        {

            player1cooked = true;

        }
        isCooked();
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player1"))
        {

            player1cooked = false;

        }
       
    }









    void isCooked()
    {

        if (player1cooked)

        {
            Debug.Log("player 1 død");
        }


    }
}
