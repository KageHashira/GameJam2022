using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EscapeActions : MonoBehaviour
{
    [SerializeField] UnityEvent onEscapeActions;
    private void OnGUI() {
        if(Event.current != null && Event.current.type == EventType.KeyDown)
        {
            if(Event.current.keyCode == KeyCode.Escape)
            {
                onEscapeActions.Invoke();
            }
        }
    }
    public void invokeEscapeActions()
    {
        onEscapeActions.Invoke();
    }
}
