using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Player))]
public class UserControl : MonoBehaviour
{
    private Player character;
    private bool jump;
    private bool crouch;

    // Use this for initialization
    void Start()
    {
        character = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!jump)
        {
            jump = Input.GetButtonDown("Jump");
        }
    }

    void FixedUpdate()
    {
        crouch = Input.GetKey(KeyCode.LeftControl);
        float h = Input.GetAxis("Horizontal");
        character.Move(h, crouch, jump);
        jump = false;
    }
}
