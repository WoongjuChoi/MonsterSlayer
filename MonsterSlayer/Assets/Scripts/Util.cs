using UnityEditor;
using UnityEngine;

class AnimParameter
{
    public const string ATTACK = "Attack";
    public const string HORIZONTAL = "Horizontal";
    public const string DIE = "Die";
    public const string WIN = "Win";
    public const string SKILL = "Skill";
    public const string STUN = "Stun";
}

class TagNames
{
    public const string PLAYER = "Player";
    public const string WEAPON = "Weapon";
    public const string SKILL = "Skill";
    public const string DEADZONE = "DeadZone";
    public const string BOOM = "Boom";
}

public enum EnemyType
{
    SkeletonSlave = 0,
    Boom  = 1,
}