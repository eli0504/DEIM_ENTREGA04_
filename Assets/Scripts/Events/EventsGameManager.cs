using UnityEngine;

public class EventsGameManager : MonoBehaviour
{
    // HERE YOU WILL HAVE TO DECLARE AND INVOKE THE EVENTS
    public delegate void EnterKeyPressed();
    public static event EnterKeyPressed OnEnterKeyPressed;

    public delegate void EscapeKeyPressed();
    public static event EscapeKeyPressed OnEscapeKeyPressed;

   public void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (OnEnterKeyPressed != null)
                OnEnterKeyPressed(); //invoke the event

        }else if (Input.GetKeyDown(KeyCode.Escape))

            {
            if (OnEscapeKeyPressed != null)
                OnEscapeKeyPressed(); //invoke the event
        }
    }
}
