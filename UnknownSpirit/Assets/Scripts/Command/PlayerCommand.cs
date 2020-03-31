using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAction
{
    IDLE,
    WALK,
    SHOOT
}

public class PlayerCommand : ICommand
{
    private readonly Player _player;
    private readonly PlayerAction _playerAction;

    public PlayerCommand()
    {

    }

    public void ExecuteAction()
    {
        throw new System.NotImplementedException();
    }
}
