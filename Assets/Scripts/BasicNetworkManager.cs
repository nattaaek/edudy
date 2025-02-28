using UnityEngine;
using Mirror;

public class BasicNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Vector3 spawnPosition = GetStartPosition() ? GetStartPosition().position : Vector3.zero;
        GameObject player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
