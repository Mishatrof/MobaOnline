using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Controller : MonoBehaviourPunCallbacks
{
    public PhotonView photonView;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!photonView.IsMine)
            return;

        GetComponent<Rigidbody2D>().AddForce(
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed, ForceMode2D.Force);
    }
}
