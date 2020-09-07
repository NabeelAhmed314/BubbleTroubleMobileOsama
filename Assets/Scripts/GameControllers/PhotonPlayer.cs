using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView PV;
    public GameObject myAvatar;
    public GameObject myShooter;
    public int spawn;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"),
                GameSetup.GS.spawnPoints[spawn].position, GameSetup.GS.spawnPoints[spawn].rotation, 0);
            myShooter = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "ChainShooter"),
                GameSetup.GS.spawnPoints[spawn].position, GameSetup.GS.spawnPoints[spawn].rotation, 0);
            myShooter.transform.GetComponent<Chain>().player = myAvatar.transform;
            myShooter.transform.GetComponent<Chain>().firebtn = FindObjectOfType<FixedButton1>();
            myAvatar.transform.GetComponent<Player>().joystick = FindObjectOfType<FixedJoystick>();
        }
    }
}
