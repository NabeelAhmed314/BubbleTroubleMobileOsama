using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ChainManager : MonoBehaviour
{
    private PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (!PV.IsMine)
        {
            transform.GetComponent<Chain>().enabled = false;
        }
    }
}
