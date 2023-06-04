using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public CharacterController2D player1;
    public CharacterController2D player2;
    public Launcher player1Launcher;
    public Launcher player2Launcher;
    public GameObject mountPoint1;
    public GameObject mountPoint2;

    void Start()
    {
        mountPoint1.transform.SetParent(player1.transform);
        player1Launcher.transform.SetParent(mountPoint1.transform);
        mountPoint2.transform.SetParent(player2.transform);
        player2Launcher.transform.SetParent(mountPoint2.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}