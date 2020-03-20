using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class swirp : MonoBehaviour
{


    private float fingerActionSensitivity = Screen.width * 0.05f; //手指动作的敏感度，这里设定为 二十分之一的屏幕宽度.
    public AudioSource source;
    public AudioClip[]   clip;
    public AudioClip[]   clip2;
    public int[] time1 = { 20, 15, 15, 12 };
    public int count1=0;
    public int count2 = 0;
    private float fingerBeginX;
    private float fingerBeginY;
    private float fingerCurrentX;
    private float fingerCurrentY;
    private float fingerSegmentX;
    private float fingerSegmentY;

    //
    private int fingerTouchState;
    //
    private int FINGER_STATE_NULL = 0;
    private int FINGER_STATE_TOUCH = 1;
    private int FINGER_STATE_ADD = 2;
    // Use this for initialization
    void Start()
    {
        fingerActionSensitivity = Screen.width * 0.05f;
        source.clip = clip[0];
        fingerBeginX = 0;
        fingerBeginY = 0;
        fingerCurrentX = 0;
        fingerCurrentY = 0;
        fingerSegmentX = 0;
        fingerSegmentY = 0;

        fingerTouchState = FINGER_STATE_NULL;
    }
    // Update is called once per frame
    void Update()
    { 

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (fingerTouchState == FINGER_STATE_NULL)
            {
                fingerTouchState = FINGER_STATE_TOUCH;
                fingerBeginX = Input.mousePosition.x;
                fingerBeginY = Input.mousePosition.y;
            }

        }

        if (fingerTouchState == FINGER_STATE_TOUCH)
        {
            fingerCurrentX = Input.mousePosition.x;
            fingerCurrentY = Input.mousePosition.y;
            fingerSegmentX = fingerCurrentX - fingerBeginX;
            fingerSegmentY = fingerCurrentY - fingerBeginY;

        }


        if (fingerTouchState == FINGER_STATE_TOUCH)
        {
            float fingerDistance = fingerSegmentX * fingerSegmentX + fingerSegmentY * fingerSegmentY;

            if (fingerDistance > (fingerActionSensitivity * fingerActionSensitivity))
            {
                toAddFingerAction();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            fingerTouchState = FINGER_STATE_NULL;
        }
    }

    void delayOpenRight()
    {
        count1++;
        if (count1 > 3)
            count2++;

        if (count1 == 5)
            count1 = 0;
        source.clip = clip[count1];
        source.Play();
    }
    void delayOpenLeft()
    {
        if (count1 >= 0)
            count1--;
        if (count1 == -1)
        {
            if (count2 == 0)
            {
                source.clip = clip[5];
                source.Play();
            }
            else
            {
                count1 = 4;
                source.clip = clip[count1];
                source.Play();
            }
        }
        else
        {
            source.clip = clip[count1];
            source.Play();
        }
    }

    private void toAddFingerAction()
    {

        fingerTouchState = FINGER_STATE_ADD;

        if (Mathf.Abs(fingerSegmentX) > Mathf.Abs(fingerSegmentY))
        {
            fingerSegmentY = 0;
        }
        else
        {
            fingerSegmentX = 0;
        }

        if (fingerSegmentX == 0)
        {
            if (fingerSegmentY > 0)
            {
                Debug.Log("up");
                Handheld.Vibrate();
            }
            else
            {
                Debug.Log("down");
                Handheld.Vibrate();
                if (count1 == 4)
                {
                    SceneManager.LoadScene("Tutorial");
                }
                else
                {

                    //source.clip = clip2[count1];
                    //source.Play();
                    //soure.clip = clip[count1];
                    //source.PlayDelayed(time1[count1]);


                    //Invoke("delayOpen",time1[count1]);
                    //source.clip = clip[count1];
                    //source.Play();
                    //Debug.Log("123456");
                   // source.Play();
                }
            }
        }
        else if (fingerSegmentY == 0)
        {
            if (fingerSegmentX > 0)
            {
                Debug.Log("right");
                Handheld.Vibrate();
                source.clip = clip[6];
                source.Play();
                Invoke("delayOpenRight",1);
               // count1++;
               // if (count1 > 3)
               //     count2++;

               //if (count1 == 5)
               //     count1 = 0;
               // source.clip = clip[count1];
               // source.Play();
            }
            else
            {
                Debug.Log("left");
                Handheld.Vibrate();
                source.clip = clip[7];
                source.Play();
                Invoke("delayOpenLeft", 1);

                /*if (count1 >=0)
                    count1--;
                if (count1 == -1)
                {
                    if (count2 == 0)
                    {
                        source.clip = clip[5];
                        source.Play();
                    }
                    else
                    {
                        count1 = 4;
                        source.clip = clip[count1];
                        source.Play();
                    }
                }
                else
                {
                    source.clip = clip[count1];
                    source.Play();
                }*/
            }
        }

    }
}