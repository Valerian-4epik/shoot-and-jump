using UnityEngine;

public class DartsManager : MonoBehaviour
{
    private FinishPanel _panel;

    public void SetValue(Color color, string bonus)
    {
        _panel.gameObject.SetActive(true);
        _panel.ShowResults(color, bonus);
    }

    public FinishPanel Panel(FinishPanel panel)
    {
        return _panel = panel;
    }
}
