using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PointsView : MonoBehaviour
{
    [SerializeField] private PointsController pointsController;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
        pointsController.onPointsUpdated += UpdatePoints;
    }

    private void OnDestroy()
    {
        pointsController.onPointsUpdated -= UpdatePoints;
    }

    private void UpdatePoints(int points)
    {
        _text.text = points.ToString();
    }
}
