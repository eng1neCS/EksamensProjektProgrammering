using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] new GameObject DoorP1;
    [SerializeField] new GameObject DoorP2;

    [SerializeField] bool isDoorOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            //if (!isDoorOpen)
            //{
            //    OpenDoor();
            //}
            if (DoorP1 != null && collision.CompareTag("Player1"))
            {
                // Play Door 1 animation
                Debug.Log("Player 1 entered the door trigger");
            }
            else if (DoorP2 != null && collision.CompareTag("Player2"))
            {
                // Play Door 2 animation
                Debug.Log("Player 2 entered the door trigger");
            }
            

        }

    }


    //private void OpenDoor()
    //{
    //    isDoorOpen = true;

    //    if (/*/onCollisionEnter2D.CompareTag("Player1")*/)
    //    {
    //        //spil Door 1 animation
    //    }
    //    else if (/*OnTriggerEnter2D.CompareTag("Player2")*/)
    //    {
    //        //spil Door 2 animation
    //    }
    //}


}
