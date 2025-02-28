using UnityEngine;
using Mirror;
using TMPro;

public class ChatManager : NetworkBehaviour
{
    public TMP_InputField chatInput;
    public TextMeshProUGUI chatDisplay;
    public void OnSendChat()
    {
        if (!string.IsNullOrEmpty(chatInput.text))
        {
            CmdSendMessage(chatInput.text);
            chatInput.text = "";        
        }
    }

    [Command]
    void CmdSendMessage(string message)
    {
        string formattedMessage = $"Player {connectionToClient.connectionId}: {message}";
        RpcReceiveMessage(message);
    }

    [ClientRpc]
    void RpcReceiveMessage(string message)
    {
        chatDisplay.text += "\n" + message;
    }
}
