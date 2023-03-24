using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;
public class NetworkScoreManager : NetworkBehaviour
{
  //  [SerializeField] private int score = 0;
    [SerializeField] private NetworkVariable<int> score = new NetworkVariable<int>(0); // Add this code to add anything like hitpoints
    private void Initialise()
    {
        score.Value = 0;
    }

    //Stats on game start
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Initialise();
    }

    public void IncreaseScore()
    {
        score.Value += 1;
    }

    private void Update()
    {
        if (IsOwner == false) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseScore();
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(30, 30, 200, 40));
        GUILayout.Label("Score: " + score.Value);
        GUILayout.EndArea();
    }
}
