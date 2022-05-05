using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance { set; get; }

    public Server server;
    public Client client;

    [SerializeField] private TMP_InputField addressInput;

    public void Awake()
    {
        Instance = this;
    }

    public void OnLocalGameButton()
    {
        
    }

    public void OnOnlineGameButton()
    {

    }

    public void OnOnlineConnectButton()
    {
        client.Init(addressInput.text, 8007);
    }

    public void OnOnlineHostButton()
    {
        server.Init(8007);
        client.Init("127.0.0.1", 8007);
    }
}
