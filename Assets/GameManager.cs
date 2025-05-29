using Cinemachine;
using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour , INetworkRunnerCallbacks
{
    private int nemiciUccisi;
    public CinemachineVirtualCamera playerFollowCamera;
    public GameObject personaggioPrefab;
    public Transform spawnPointPersonaggio;

  

   

    // Start is called before the first frame update
    void Start()
    {
       // SpawnPersonaggio();
       Connetti();
    }

    private void Connetti()
    {
        NetworkRunner networkRunner = GetComponent<NetworkRunner>();
        StartGameArgs args = new StartGameArgs();
        args.SessionName = "PartitinaFormatica";
        args.PlayerCount = 10;
        args.GameMode = GameMode.Shared;

        networkRunner.StartGame(args);
    }

    private void SpawnPersonaggio()
    {
       GameObject personaggioSpawnato =  Instantiate(personaggioPrefab, spawnPointPersonaggio.position, spawnPointPersonaggio.rotation);
       PlayerCameraRoot playerCameraRoot = personaggioSpawnato.GetComponentInChildren<PlayerCameraRoot>();
       playerFollowCamera.Follow = playerCameraRoot.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {

        Debug.Log("Connesso!");
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }
}
