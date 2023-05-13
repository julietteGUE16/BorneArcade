using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public GameObject spriteRendererLooseLife;
    public weapon weapon;
    private Rigidbody2D rb;
    menuController menuController;
    public int playerNumber;
    private Vector2 smoothDampVelocity;
    public float smoothDampTime = 0.1f;
    Vector2 stickPosition;
    public bool isStartLeft;
    public bool isStartFinish = false;
    public Vector2 movement = Vector2.zero;
    public Vector2 lastMovement = Vector2.zero;
    public Image life1;
    public Image life2;
    public Image life3;
    public Image life4;
    public Image life5;
    public Color lifeLose;
    public bool isEnd = false;

    public gameSet gameSet;
    public string playerName = "";
    public float speed = 10f;
    public float rotationSpeed = 5f;
    public int life = 5;
    public float delayFire = 0.2f;
    public float powerFire = 1f;
    public float speedFire = 10f;
    public float score = 0f;
    EventSystem eventSystem;
    public bool canFire = true;
    startRound startRound;
    Joystick j2;
    Gamepad g2;

    void Start()
    {
        gameSet = GameObject.FindObjectOfType<gameSet>();
        spriteRendererLooseLife.GetComponent<SpriteRenderer>().enabled = false;
        startRound = GameObject.FindObjectOfType<startRound>();
        menuController = GameObject.FindObjectOfType<menuController>();

        speed = speed * 10;
        rotationSpeed = rotationSpeed * 600;
        delayFire = delayFire / 10;
        powerFire = powerFire / 2;

        eventSystem = EventSystem.current;
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 0.25f;
        var devices = InputSystem.devices;
        if (playerNumber == 0)
        {
            j2 = gameSet.j1 != null ? gameSet.j1 : null;
            g2 = gameSet.g1 != null ? gameSet.g1 : null;
        }
        else if (playerNumber == 1)
        {
            j2 = gameSet.j2 != null ? gameSet.j2 : null;
            g2 = gameSet.g2 != null ? gameSet.g2 : null;
        }
    }

    void Update()
    {
        switch (life)
        {
            case 4:
                life5.color = lifeLose;
                break;
            case 3:
                life4.color = lifeLose;
                break;
            case 2:
                life3.color = lifeLose;
                break;
            case 1:
                life2.color = lifeLose;
                break;
            case 0:
                if (!isEnd)
                {
                    isEnd = true;
                    life1.color = lifeLose;
                    startRound.isEnd = true;
                    StartCoroutine(EndGame());
                }
                break;
        }

        if (j2 != null)
        {
            stickPosition = j2.stick.ReadValue();
            rb.velocity = stickPosition * speed;

            if (j2.trigger.value == 1)
            {
                if (canFire)
                {
                    weapon.playerMovement = lastMovement.normalized;
                    weapon.EffectuerTir(powerFire);
                    StartCoroutine(FireRate());
                }
               }
    }
    else if (g2 != null)
    {
        stickPosition = g2.leftStick.ReadValue();
        Vector2 targetVelocity = stickPosition * speed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref smoothDampVelocity, smoothDampTime);
        movement = stickPosition;

        if (movement != Vector2.zero)
        {
            lastMovement = movement;
        }

        if (g2.buttonSouth.wasPressedThisFrame)
        {
            if (canFire)
            {
                weapon.playerMovement = lastMovement.normalized;
                weapon.EffectuerTir(powerFire);
                StartCoroutine(FireRate());
            }
        }
    }

    Vector2 movementDirection = stickPosition.normalized;

    if (movementDirection != Vector2.zero)
    {
        float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;

        if (!isStartFinish)
        {
            isStartFinish = true;

            if (movementDirection.x < 0f)
            {
                if (isStartLeft)
                {
                    angle += 180f;
                }
            }
        }

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

public IEnumerator EndGame()
{
    yield return new WaitForSeconds(1.6f);
    menuController.loadAllScene("endGame");
}

public IEnumerator FireRate()
{
    canFire = false;
    yield return new WaitForSeconds(delayFire);
    canFire = true;
}

public float getScore()
{
    float time = startRound.StopAndGetChronometer();
    float timeScore = 1f / time;
    float lifeScore = (float)life + 1f;
    float speedScore = (speed - 10f) / 90f;
    float rotationScore = (6000f - rotationSpeed) / 5400f;
    float delayFireScore = (1f - delayFire) / 0.9f;
    float powerFireScore = (5f - powerFire) / 4.5f;

    float score = timeScore * 0.3f + speedScore * 0.1f + rotationScore * 0.1f + delayFireScore * 0.1f + powerFireScore * 0.2f;
    score = (score * lifeScore) * 1000f;

    if (life > 0)
    {
        score += 500f;
    }

   

    return score;
}

    public IEnumerator waitLooseLife()
    {
        yield return new WaitForSeconds(0.03f);
        spriteRendererLooseLife.GetComponent<SpriteRenderer>().enabled = false;
    }

}