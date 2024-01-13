using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class InputPlayer : NetworkBehaviour
{
    public GameObject prefab;


    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShootServerRpc();
        }
    }


    [ServerRpc(RequireOwnership = true)]
    private void ShootServerRpc(ServerRpcParams s = default)
    {
        NetworkObject nobj = Instantiate(prefab, Vector3.zero, Quaternion.identity).GetComponent<NetworkObject>();
        nobj.SpawnWithOwnership(s.Receive.SenderClientId);
    }
}
