using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    private float movementSpeed = 3f;

    void Update()
    {
        if (IsOwner == false || Application.isFocused == false) return;

        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * movementSpeed;
    }
}
