using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
