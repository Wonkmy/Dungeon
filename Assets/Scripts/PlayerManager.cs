using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed { get; set; }
    public PlayerMoveDirection moveDirection { get; set; }

    public void SetPlayerPosition()
    {
        transform.position = MapGenerator.instance.GetChunkViewByCID(0).transform.position;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection = PlayerMoveDirection.UP;
            transform.DOMoveY(transform.position.y + 1, moveSpeed);
        }else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection = PlayerMoveDirection.DOWN;
            transform.DOMoveY(transform.position.y - 1, moveSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection = PlayerMoveDirection.LEFT;
            transform.DOMoveX(transform.position.x - 1, moveSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection = PlayerMoveDirection.RIGHT;
            transform.DOMoveX(transform.position.x + 1, moveSpeed);
        }

    }
}
