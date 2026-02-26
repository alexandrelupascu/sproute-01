using System;
using UnityEngine;
using UnityUtils;


public class DebugManager : PersistentSingleton<DebugManager>
{
    
    [SerializeField] bool _debugMode;
    [SerializeField] bool _playerInfo = true;
    [SerializeField] bool _enemyInfo = true;
    [SerializeField] bool _attackHitboxes = true;
    
    
    public event Action<bool> PlayerInfoChanged;
    public event Action<bool> EnemyInfoChanged;
    public event Action<bool> AttackHitboxesChanged;

    
    public bool DebugMode
    {
        get => _debugMode;
        set
        {
            if (_debugMode == value) return;

            _debugMode = value;

            PlayerInfoChanged?.Invoke(_debugMode && _playerInfo);
            EnemyInfoChanged?.Invoke(_debugMode && _enemyInfo);
            AttackHitboxesChanged?.Invoke(_debugMode && _attackHitboxes);
        }
    }

    public bool PlayerInfo
    {
        get => _debugMode && _playerInfo;
        set
        {
            if (_playerInfo == value) return;
            _playerInfo = value;
            PlayerInfoChanged?.Invoke(_debugMode && _playerInfo);
        }
    }

    public bool EnemyInfo
    {
        get => _debugMode && _enemyInfo;
        set
        {
            if (_enemyInfo == value) return;
            _enemyInfo = value;
            EnemyInfoChanged?.Invoke(_debugMode && _enemyInfo);
        }
    }

    public bool AttackHitboxes
    {
        get => _debugMode && _attackHitboxes;
        set
        {
            if (_attackHitboxes == value) return;
            _attackHitboxes = value;
            AttackHitboxesChanged?.Invoke(_debugMode && _attackHitboxes);
        }
    }
}