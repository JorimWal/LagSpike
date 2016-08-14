using UnityEngine;
using UnityEngine.UI;

public class PlayMenuController : MonoBehaviour
{
	public GameObject PowerUpToggle;
	public Slider LagSlider;
	public InputField LagInput;

	public void SliderChanged()
	{
		LagInput.text = ((int)LagSlider.value).ToString();
	}

	public void InputChanged()
	{
		try
		{
			LagSlider.value = int.Parse(LagInput.text);
			LagInput.text = LagSlider.value.ToString();
		}
		catch { }
	}
}