using UnityEditor;
using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour
{
    public static Vector3 PlayerLeftPosition = new Vector3(-10f, 0f, 3.3f);
    public static Vector3 PlayerMiddlePosition = new Vector3(-10f, 0f, 0f);
    public static Vector3 PlayerRightPosition = new Vector3(-10f, 0f, -3.3f);

    public static Vector3 EnemyLeftPosition = new Vector3(7f, 0f, 3.3f);
    public static Vector3 EnemyMiddlePosition = new Vector3(7f, 0f, 0f);
    public static Vector3 EnemyRightPosition = new Vector3(7f, 0f, -3.3f);
}