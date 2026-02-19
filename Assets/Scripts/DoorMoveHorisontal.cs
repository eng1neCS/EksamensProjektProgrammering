using UnityEngine;

public class DoorMoveH : MonoBehaviour
{
    public void MoveDoorH()
    {
        float doorSize = transform.localScale.x;
        transform.position += new Vector3(doorSize, 0, 0);
    }
}
