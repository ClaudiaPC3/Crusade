using UnityEngine;

using UnityEngine.Networking;



public class manager : NetworkManager
{
    public void OnConnectedToServer()
    {
        GlobalData.EnCurso = true;
    }
}


