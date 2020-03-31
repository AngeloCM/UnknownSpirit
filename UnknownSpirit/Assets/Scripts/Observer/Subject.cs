using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SubjectState
{
    IDLE,
    WALK,
    SHOT
}

public class Subject : ISubject
{
    public SubjectState subjectState { get; protected set; }

    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        Debug.Log("Subject: Attached an observer.");
        this._observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this._observers.Remove(observer);
        Debug.Log("Subject: Detached an observer.");
    }

    public void Notify()    
    {
        Debug.Log("Subject: Notifying observers...");

        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }
}
