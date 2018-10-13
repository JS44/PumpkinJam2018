using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightLight : MonoBehaviour
{

    public float rotateSpeed = 0.01f;
    public float timer = 0;
    public float nightToDayRatio = 1;
    public bool shouldTimerIncrease;

    private float nightMult;
    private float dayMult;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        nightMult = nightToDayRatio;
        dayMult = 1 / nightToDayRatio;
    }

    // Update is called once per frame
    void Update()
    {
        float currentXRot = transform.rotation.eulerAngles.x;

        if (currentXRot < 90 & currentXRot > 20)
        {
            transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime * nightMult);
        }
        else
        {
            transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime * dayMult);
        }

        if (shouldTimerIncrease)
        {
            timer = timer + Time.deltaTime;
        }

    }

    public float GetGameTime()
    {
        return timer;
    }
}
