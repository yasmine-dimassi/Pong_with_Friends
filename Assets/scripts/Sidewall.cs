using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidewall : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "Ball")
        {
            string wallName = transform.name;
            Photon.Pun.Demo.PunBasics.MultiplayerGameController.Score(wallName);
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
