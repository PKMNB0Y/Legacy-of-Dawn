﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public static Player p;
    public Bullet shot, shot2;
    public Controller cont;
    public Orbiter a, b;
    public LaserShot c;
    public AudioClip shooting, bzzt, bomb;

    public SpriteRenderer spriteRenderer;
    public Sprite focus;
    public Sprite unfocus;
    public int charX;
    public int charY;
    public int counter;
    public int invulnTimer;
    public int bombCD, bombTimer;
    public bool dead;

	// Use this for initialization
	void Start () {
        if (p == null)
        {
            DontDestroyOnLoad(gameObject);
            p = this;
        }
        else if (p != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!Controller.Instance.paused)
        {
            Movement();
            Fire();
            iFrame();
            counter++;
            if (!dead)
            {
                BombActive();
            }
        }
        if (dead)
        {
            Controller.Instance.paused = true;
        }
	}


    void Movement()
    {
        if (!dead)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                spriteRenderer.sprite = focus;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (transform.position.y + .0625f < 19 - (charY / 2))
                    {
                        transform.position += new Vector3(0, .0625f, 0);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, 19 - (charY / 2), 0);
                    }
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (transform.position.y - .0625f > 1 + (charY / 2))
                    {
                        transform.position += new Vector3(0, -.0625f, 0);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, 1 + (charY / 2), 0);
                    }
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (transform.position.x - .0625f > -11f - (charX / 2))
                    {
                        transform.position += new Vector3(-.0625f, 0, 0);
                    }
                    else
                    {
                        transform.position = new Vector3(-11f + (charX / 2), transform.position.y, 0);
                    }
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (transform.position.x + .0625f < 3f - (charX / 2))
                    {
                        transform.position += new Vector3(.0625f, 0, 0);
                    }
                    else
                    {
                        transform.position = new Vector3(3f + (charX / 2), transform.position.y, 0);
                    }
                }
            }
            else
            {
                spriteRenderer.sprite = unfocus;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (transform.position.y + .125f < 19 - (charY / 2))
                    {
                        transform.position += new Vector3(0, .125f, 0);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, 19 - (charY / 2), 0);
                    }
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (transform.position.y - .125f > 1 + (charY / 2))
                    {
                        transform.position += new Vector3(0, -0.125f, 0);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, 1 + (charY / 2), 0);
                    }
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (transform.position.x - .125f > -11f - (charX / 2))
                    {
                        transform.position += new Vector3(-0.125f, 0, 0);
                    }
                    else
                    {
                        transform.position = new Vector3(-11f + (charX / 2), transform.position.y, 0);
                    }
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (transform.position.x + .125f < 3f - (charX / 2))
                    {
                        transform.position += new Vector3(0.125f, 0, 0);
                    }
                    else
                    {
                        transform.position = new Vector3(3f + (charX / 2), transform.position.y, 0);
                    }
                }
            }
        }
    }

    void Fire()
    {
        if (!dead)
        {
            if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
            {
                Sound.me.PlaySound(bzzt, .1f, 47, 48);
                if (Controller.Instance.power < 2f)
                {
                    counter = 0;
                    a.on = false;
                    b.on = false;
                    c.on = true;
                    if (Controller.Instance.laserProcTimer > 10)
                    {
                        Controller.Instance.dmg2 = 4;
                        Controller.Instance.laserProcTimer = 0;
                    }
                    else
                    {
                        Controller.Instance.dmg2 = 0;
                        Controller.Instance.laserProcTimer++;
                    }
                }
                else if (Controller.Instance.power < 3f)
                {
                    counter = 0;
                    a.on = false;
                    b.on = false;
                    c.on = true;
                    if (Controller.Instance.laserProcTimer > 10)
                    {
                        Controller.Instance.dmg2 = 8;
                        Controller.Instance.laserProcTimer = 0;
                    }
                    else
                    {
                        Controller.Instance.dmg2 = 0;
                        Controller.Instance.laserProcTimer++;
                    }
                }
                else if (Controller.Instance.power < 4f)
                {

                    counter = 0;
                    a.on = false;
                    b.on = false;
                    c.on = true;
                    if (Controller.Instance.laserProcTimer > 10)
                    {
                        Controller.Instance.dmg2 = 12;
                        Controller.Instance.laserProcTimer = 0;
                    }
                    else
                    {
                        Controller.Instance.dmg2 = 0;
                        Controller.Instance.laserProcTimer++;
                    }
                }
                else if (Controller.Instance.power < 5f)
                {

                    counter = 0;
                    a.on = false;
                    b.on = false;
                    c.on = true;
                    if (Controller.Instance.laserProcTimer > 10)
                    {
                        Controller.Instance.dmg2 = 16;
                        Controller.Instance.laserProcTimer = 0;
                    }
                    else
                    {
                        Controller.Instance.dmg2 = 0;
                        Controller.Instance.laserProcTimer++;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                if (counter > 2)
                {
                    Sound.me.PlaySound(shooting, .05f, 45, 46);
                    if (Controller.Instance.power < 2f)
                    {
                        Vector3 offset1 = new Vector3(.25f, 0, 0);
                        Vector3 offset2 = new Vector3(-.25f, 0, 0);
                        Bullet Copy = (Instantiate(shot, transform.position + offset1, transform.rotation)) as Bullet;
                        Bullet Copy2 = (Instantiate(shot, transform.position + offset2, transform.rotation)) as Bullet;
                        counter = 0;
                        a.on = false;
                        b.on = false;
                    }
                    else if (Controller.Instance.power < 3f)
                    {
                        Vector3 offset1 = new Vector3(.25f, 0, 0);
                        Vector3 offset2 = new Vector3(-.25f, 0, 0);
                        Vector3 offset3 = new Vector3(0, .25f, 0);
                        Vector3 offset4 = new Vector3(-.5f, 0, 0);
                        Vector3 offset5 = new Vector3(.5f, 0, 0);
                        Bullet Copy = (Instantiate(shot, transform.position + offset1, transform.rotation)) as Bullet;
                        Bullet Copy2 = (Instantiate(shot, transform.position + offset2, transform.rotation)) as Bullet;
                        Bullet Copy3 = (Instantiate(shot, transform.position + offset3, transform.rotation)) as Bullet;
                        Bullet Copy4 = (Instantiate(shot2, transform.position + offset4, transform.rotation)) as Bullet;
                        Bullet Copy5 = (Instantiate(shot2, transform.position + offset5, transform.rotation)) as Bullet;
                        counter = 0;
                        a.on = false;
                        b.on = false;
                    }
                    else if (Controller.Instance.power < 4f)
                    {
                        Vector3 offset1 = new Vector3(.25f, 0, 0);
                        Vector3 offset2 = new Vector3(-.25f, 0, 0);
                        Vector3 offset3 = new Vector3(0, .25f, 0);
                        Vector3 offset4 = new Vector3(-.5f, 0, 0);
                        Vector3 offset5 = new Vector3(.5f, 0, 0);
                        Bullet Copy = (Instantiate(shot, transform.position + offset1, transform.rotation)) as Bullet;
                        Bullet Copy2 = (Instantiate(shot, transform.position + offset2, transform.rotation)) as Bullet;
                        Bullet Copy3 = (Instantiate(shot, transform.position + offset3, transform.rotation)) as Bullet;
                        Bullet Copy4 = (Instantiate(shot2, transform.position + offset4, transform.rotation)) as Bullet;
                        Bullet Copy5 = (Instantiate(shot2, transform.position + offset5, transform.rotation)) as Bullet;
                        counter = 0;
                        a.on = true;
                        b.on = false;
                    }
                    else if (Controller.Instance.power < 5f)
                    {
                        Vector3 offset1 = new Vector3(.25f, 0, 0);
                        Vector3 offset2 = new Vector3(-.25f, 0, 0);
                        Vector3 offset3 = new Vector3(0, .25f, 0);
                        Vector3 offset4 = new Vector3(-.5f, 0, 0);
                        Vector3 offset5 = new Vector3(.5f, 0, 0);
                        Bullet Copy = (Instantiate(shot, transform.position + offset1, transform.rotation)) as Bullet;
                        Bullet Copy2 = (Instantiate(shot, transform.position + offset2, transform.rotation)) as Bullet;
                        Bullet Copy3 = (Instantiate(shot, transform.position + offset3, transform.rotation)) as Bullet;
                        Bullet Copy4 = (Instantiate(shot2, transform.position + offset4, transform.rotation)) as Bullet;
                        Bullet Copy5 = (Instantiate(shot2, transform.position + offset5, transform.rotation)) as Bullet;
                        counter = 0;
                        a.on = true;
                        b.on = true;
                    }
                }
            }
        }
    }

    void iFrame()
    {
        if (Controller.Instance.invuln)
        {
            if (invulnTimer < 60)
            {
                invulnTimer++;
            }
            else
            {
                Controller.Instance.invuln = false;
                invulnTimer = 0;
            }
        }
    }

    void BombActive()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (Controller.Instance.bombs > 0)
            {
                if (bombCD > 240)
                {
                    Controller.Instance.bombs--;
                    Controller.Instance.bombing = true;
                    GameObject blah = Instantiate(Controller.Instance.bombAni, transform.position, Quaternion.identity);
                    blah.transform.Rotate(new Vector3(-90, 0, 0));
                    blah.transform.parent = gameObject.transform;
                    blah.transform.position += new Vector3(0, 1.5f, 1);
                    Sound.me.PlaySound(bomb, .1f, 50, 51);
                    bombTimer = 240;
                }
            }
        }
        if (bombCD < 241)
        {
            bombCD++;
        }
        if (bombTimer > 0)
        {
            bombTimer--;
        }
        else if (bombTimer == 0)
        {
            Controller.Instance.bombing = false;
        }
    }
}
