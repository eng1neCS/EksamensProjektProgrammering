using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private string DoorID = "Door1";
    [SerializeField] private string playerID = "P2";

    [SerializeField] bool isDoorOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
            //if (!isDoorOpen)
            //{
            //    OpenDoor();
            //}
            if (DoorID != null)
            {
                if (collision.GetComponent<MovementScript>().PlayerID == playerID)
                {

                }
                // Play Door animation
                isDoorOpen = true;
                Debug.Log(playerID + " has entered the" + DoorID + "trigger");
                transform.parent.GetComponent<GameManager>()?.DoorOpened(1);
            }

           
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (DoorID != null)
            {
                if (collision.GetComponent<MovementScript>().PlayerID == playerID)
                {
                }
                // Play Door animation
                isDoorOpen = false;
                Debug.Log(playerID + " has exited the" + DoorID + "trigger");
                transform.parent.GetComponent<GameManager>()?.DoorOpened(-1);
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
