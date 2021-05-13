using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Animator anim;
    public GameObject panelCon,gameOver;
    public Text live;
    public TMP_Text record;
    public int livePl,save;
  
    public Transform groundCheck;
    public LayerMask groundMask;
    public bool dead = false;
    private bool ground = false;
    public bool paused = false, cont = false;
    private float groundRadius = 0.5f;
    private void Start()
    {
        anim = GetComponent<Animator>();
        livePl = 2;
        Time.timeScale = 1;
        paused = false;
        save = PlayerPrefs.GetInt("record");
    }

    private void Update()
    {
        if(dead==true)
        {
            if (save >= GameObject.Find("GameManager").GetComponent<GameManager>().score)
            {
                record.text = save.ToString();
            }
            else
            {
                record.text = GameObject.Find("GameManager").GetComponent<GameManager>().score.ToString();
                PlayerPrefs.SetInt("record", GameObject.Find("GameManager").GetComponent<GameManager>().score);
            }
        }
        ground = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        if (livePl == 0)
        {
            dead = true;
           
            if (cont == false)
            {
                panelCon.SetActive(true);
            }
            else
            {
                panelCon.SetActive(false);
            }
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
            }

        }
    }

    public void Jump()
    {
        if (ground == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("fall");
            livePl--;
            live.text = livePl.ToString();
        }
        if (collision.tag == "fall")
        {
            dead = true;
            gameOver.SetActive(true);
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
            }
        }
    }
}
