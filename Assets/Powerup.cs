/*
To cleanup code:
Step 1). CTRL + A
Step 2). CTRL + K + D (In that order)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Enumerator
public enum Ability
{
    NULL                = 0,
    Increase_Jump      = 1,
    Fake_Powerup     = 2,
    Decrease_Jump    = 3
}

public class Powerup : MonoBehaviour
{
    public Ability ability;
    public int powerLevel = 100;
    public Color colorStart = Color.red;
    public Color colorEnd = Color.green;
    public float duration = 1.0f;
    public float rotationSpeed = 20;
    public float bobSpread = 5;
    public float bobSpeed = 10;
    public AudioSource kek;

    private float bobTimer = 0;
    private MeshRenderer rend;
    private Vector3 spawnPos;



    // CTRL + M + O = Fold Code
    // CTRL + M + P = Unfold Code

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        spawnPos = transform.position;
        kek = GameObject.Find("Spawner").GetComponent<AudioSource>();
    }
    void Update()
    {
        // Call the Rotation function
        Rotation();
        ChangeColor();
        Bob();
    }
    void Rotation()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
    void ChangeColor()
    {
        Material mat = rend.material;
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        mat.color = Color.Lerp(colorStart, colorEnd, lerp);
    }
    void Bob()
    {
        bobTimer += bobSpeed * Time.deltaTime;
        float lerp = Mathf.PingPong(bobTimer, duration) / duration;
        // Get position
        Vector3 position = transform.position;
        position.y = spawnPos.y + Mathf.Lerp(-bobSpread, bobSpread, lerp);
        transform.position = position;
    }

    // Gets called when two objects collide
    void OnTriggerEnter2D(Collider2D col)
    {
        // Check if we are colliding with Player
        if(col.tag == "Player")
        {
            // Get the player script
            Player player = col.GetComponent<Player>();
            // Apply ability to player
            switch (ability)
            {
                case Ability.Increase_Jump:
                    player.jumpForce += powerLevel;
                    break;
                case Ability.Decrease_Jump:
                    player.jumpForce -= powerLevel * 2;
                    break;
                case Ability.Fake_Powerup:
                    kek.Play();
                    break;
                case Ability.NULL:
                default:
                    break;

            }
            Destroy(gameObject);
        }
    }

}
