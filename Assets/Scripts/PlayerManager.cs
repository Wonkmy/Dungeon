using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public void SetPlayerPosition()
    {
        transform.position = MapGenerator.instance.GetChunkViewByCID(0).transform.position;
    }
}
