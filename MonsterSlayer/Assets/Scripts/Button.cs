using UnityEditor;
using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    const float PRESSED_SCALE = 1f;
    const float UNPRESSED_SCALE = 2f;

	private GameObject _player;

    private void Awake()
    {
		_player = GameObject.FindGameObjectWithTag(TagNames.PLAYER);
	}

    public void OnButtonUp()
    {
        transform.localScale = new Vector3(transform.localScale.x, UNPRESSED_SCALE, transform.localScale.z);
    }

    public void OnButtonDown()
    {
        transform.localScale = new Vector3(transform.localScale.x, PRESSED_SCALE, transform.localScale.z);

        _player.GetComponent<PlayerMovement>()?.PlayerAttack();
        _player.GetComponent<PlayerMovement>()?.SetPlayerPosition(gameObject.tag);
    }
}