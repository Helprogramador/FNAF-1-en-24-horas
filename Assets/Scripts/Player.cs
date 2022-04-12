using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speedH;
    public float speedV;
    public float minRotateY;
    public float maxRotateY;
    public float timer;
    public float hora;
    public GameObject puertaL;
    public GameObject puertaR;
    public GameObject benito_camela;
    public Image usage;
    public Sprite Usage_Shape_0;
    public Sprite Usage_Shape_1;
    public Sprite Usage_Shape_2;
    public Sprite Usage_Shape_3;
    public Sprite Usage_Shape_4;
    public Text power_left;
    public int energy;
    public int energia;
    public int min_energia;
    public bool m_L;
    public bool m_R;
    public bool cam_enabled;
    public AudioSource door;
    public GameObject m_Canvas;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject m_luces;

    float yaw;
    float pitch = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        min_energia = 1;
        Cursor.lockState = CursorLockMode.Locked;
        benito_camela = GameObject.FindGameObjectWithTag("Trasicion");
    }

    // Update is called once per frame
    void Update()
    {
        hora += Time.deltaTime;
        timer += Time.deltaTime;
        energia.ToString();
        ChangeBatterrySprite();
        power_left.text = "Power left:" + energia + "%";

        if (Input.GetKeyDown("a") && !m_L)
        {
            door.Play();
            min_energia += 1;
            energy += 1;
            m_L = true;
            puertaL.GetComponent<Animator>().SetBool("True", true);
        }

        else if(Input.GetKeyDown("a") && m_L)
        {
            door.Play();
            min_energia -= 1;
            energy -= 1;
            m_L = false;
            puertaL.GetComponent<Animator>().SetBool("True", false);
        }

        else if (Input.GetKeyDown("d") && !m_R)
        {
            door.Play();
            min_energia += 1;
            energy += 1;
            m_R = true;
            puertaR.GetComponent<Animator>().SetBool("True", true);
        }

        else if(Input.GetKeyDown("d") && m_R)
        {
            door.Play();
            min_energia -= 1;
            energy -= 1;
            m_R = false;
            puertaR.GetComponent<Animator>().SetBool("True", false);
        }

        if(Input.GetKeyDown("s") && !cam_enabled)
        {
            min_energia += 1;
            energy += 1;
            cam_enabled = true;
            DisableCameras();
            EnableCamera(cam1);
        }

        else if(Input.GetKeyDown("s") && cam_enabled)
        {
            min_energia -= 1;
            energy -= 1;
            DisableCameras();
            cam_enabled = false;
            m_Canvas.SetActive(true);
            EnableCamera(cam4);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) && cam_enabled)
        {
            DisableCameras();
            EnableCamera(cam1);
        }

        else if(Input.GetKeyDown(KeyCode.Alpha2) && cam_enabled)
        {
            DisableCameras();
            EnableCamera(cam2);
        }

        else if(Input.GetKeyDown(KeyCode.Alpha3) && cam_enabled)
        {
            DisableCameras();
            EnableCamera(cam3);
        }

        if(benito_camela == null)
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch += speedV * Input.GetAxis("Mouse Y");
            transform.eulerAngles= new Vector3(pitch, yaw, -180.0f);
        }

        if(min_energia < 0)
        {
            min_energia += 1;
        }

        if(timer >= 4.5f)
        {
            timer = 0.0f;
            energia -= min_energia;
        }

        if (hora >= 480)
        {
            SceneManager.LoadScene("Ganaste");
        }

        if(energia <= 0)
        {
            LightsOut();
        }
    }

    void ChangeBatterrySprite()
    {

        if(energy == 0)
        {
            usage.sprite = Usage_Shape_0;
        }

        else if(energy == 1)
        {
            usage.sprite = Usage_Shape_1;
        }

        else if(energy == 2)
        {
            usage.sprite = Usage_Shape_2;
        }

        else if(energy == 3)
        {
            usage.sprite = Usage_Shape_3;
        }

        else if(energy == 4)
        {
            usage.sprite = Usage_Shape_4;
        }

        if (energy > 4)
        {
            energy -= 1;
        }

        else if(energy < 0)
        {
            energy += 1;
        }

    }
    void EnableCamera(GameObject cam)
    {
        cam.SetActive(true);
    }
    void DisableCameras()
    {
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        //cam4.SetActive(false);
    }
    public void LightsOut()
    {
        min_energia -= 1;
        energy -= 1;
        DisableCameras();
        cam_enabled = true;
        m_Canvas.SetActive(false);
        EnableCamera(cam4);
        m_luces.SetActive(false);
        m_Canvas.SetActive(false);
        m_R = true;
        puertaR.GetComponent<Animator>().SetBool("True", false);
        m_L = true;
        puertaL.GetComponent<Animator>().SetBool("True", false);
    }
}
