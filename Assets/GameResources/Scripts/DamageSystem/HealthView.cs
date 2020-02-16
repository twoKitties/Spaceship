using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthView : MonoBehaviour, IGameEventListener<Health>
{
    private Text _text;
    [SerializeField] private HealthEvent healthEvent;

    public void OnEventRaised(Health data)
    {
        _text.text = data.Value.ToString();
    }

    private void Awake()
    {
        _text = GetComponent<Text>();
        healthEvent.Register(this);
    }

    private void OnDestroy()
    {
        healthEvent.Unregister(this);
    }
}
