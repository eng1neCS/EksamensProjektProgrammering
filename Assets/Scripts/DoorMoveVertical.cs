using UnityEngine;

public class DoorMoveV : MonoBehaviour
{
    public void MoveDoorV()
    {
        float doorSize = transform.localScale.y;
        transform.position += new Vector3(0, doorSize, 0);
    }
}