using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonnie : MonoBehaviour
{
    // Start is called before the first frame update
    public int position = 0;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public float timer;
    public float timer_jumpscare;
    public AudioSource jumpscare;
    public Player doors;
    void Start()
    {
        CambiarPosition();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(position == 1)
        {
            gameObject.transform.position = pos1.transform.position;
        }

        else if(position == 2)
        {
            gameObject.transform.position = pos2.transform.position;
        }

        else if(position == 3)
        {
            if(!doors.m_L)
            {
                timer_jumpscare += Time.deltaTime;
            }
            gameObject.transform.position = pos3.transform.position;
        }

        if (timer >= 10)
        {
            timer = 0;
            CambiarPosition();
        }

        if (timer_jumpscare > 6)
        {
            timer_jumpscare = 6;
            doors.LightsOut();
            jumpscare.Play();
        }

        else if(timer_jumpscare == 6)
        {
            gameObject.transform.position = pos4.transform.position;
        }

        if(timer_jumpscare == 6 && timer >= 7)
        {
            SceneManager.LoadScene("SampleScene");
            gameObject.transform.position = pos4.transform.position;
        }
    }

    void CambiarPosition()
    {
        position = Random.Range(0, 4);
    }
}
