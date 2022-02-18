using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Timer : MonoBehaviour
{
    [SerializeField, Tooltip("Time passed since the timer started")]
    private float elapsedTime;

    [SerializeField, Tooltip("End of the timer")]
    private float duration = 1;
    public float Duration { set { duration = value; } }

    [SerializeField, Tooltip("Pauses the timer if true")]
    private bool pause;
    public bool Pause { set { pause = value; } }
    
    [Tooltip("Should the progress be converted as percentage")]
    private bool progressAsPercentage;
    public bool ProgressAsPrecentage { set { progressAsPercentage = value; } }

    [System.Serializable]
    public class FloatUnityEvent : UnityEvent<float> { }

    [Tooltip("Event triggered notifying listeners of the progress")]
    public FloatUnityEvent progress;

    [Tooltip("Event triggered notifying the listener that the time is over")]
    public UnityEvent completed;

    public float ElapsedTime
    {
        get 
        { 
            return elapsedTime; 
        }
        set 
        { 
            elapsedTime = value;
            progress?.Invoke(GetProgress());
        }    
    }

    public float GetProgress()
    {
        float result;

        if (progressAsPercentage)
        {
            result = Mathf.Clamp(elapsedTime / duration, 0, 1);
        }
        else
        {
            result = Mathf.Clamp(elapsedTime, 0, duration);
        }

        return result;
    }


    public void ResetTimer()
    {
        ElapsedTime = 0;
    }

    public void StartTimer()
    {
        StopAllCoroutines();
        StartCoroutine(CheckTime());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
        ResetTimer();
    }

    public void RestartTimer()
    {
        ResetTimer();
        StartTimer();
    }

    public IEnumerator CheckTime()
    { 
        while(elapsedTime < duration)
        {
            yield return new WaitWhile( ()=> pause );

            yield return new WaitForEndOfFrame();

            ElapsedTime += Time.deltaTime;
        }

        completed?.Invoke();
    }
}
