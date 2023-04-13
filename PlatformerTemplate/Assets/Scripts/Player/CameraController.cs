using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private Vector3 m_Offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, m_Target.position + m_Offset, m_Speed * Time.deltaTime);
    }
}

// using UnityEngine;

// public class CameraController : MonoBehaviour
// {
//     //Room camera
//     [SerializeField] private float speed;
//     private float currentPosX;
//     private Vector3 velocity = Vector3.zero;

//     //Follow player
//     [SerializeField] private Transform player;
//     [SerializeField] private float aheadDistance;
//     [SerializeField] private float cameraSpeed;
//     private float lookAhead;

//     private void Update()
//     {
//         //Room camera
//         // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

//         //Follow player
//         transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
//         lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
//     }

//     public void MoveToNewRoom(Transform _newRoom)
//     {
//         currentPosX = _newRoom.position.x;
//     }
// }
