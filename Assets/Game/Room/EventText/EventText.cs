using System;
using TMPro;
using UnityEngine;

public class EventText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public static event Action OnAnimEndedEvent;

    private static Animator anim;
    private static TextMeshProUGUI text;
    private static string eventAnim = "Event";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        text = _text;
    }

    public static void PlayEventAnim(string eventText)
    {
        text.text = eventText;
        anim.Play(eventAnim);
    }
    public void OnAnimEnded()
    {
        OnAnimEndedEvent?.Invoke();
    }

}
