using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Network;

public class SyncLobbyPlayer : LobbyHook {
	public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
	{
		LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
		PlayerCharacterController pcc = gamePlayer.GetComponent<PlayerCharacterController>();

		pcc.playerColor = lobby.playerColor;
	}
}