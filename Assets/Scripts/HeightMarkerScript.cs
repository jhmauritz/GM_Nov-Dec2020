using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMarkerScript : MonoBehaviour
{
    public Transform playerOne;
    public Transform playerTwo;

    private void Update()
    {
        if(playerOne != null && playerTwo != null)
        {
            Vector3 center = new Vector3((playerOne.position.x + playerTwo.position.x) * 0.5f, 
            transform.position.y, transform.position.z);
            
            transform.position = center;
        }
    }
}
