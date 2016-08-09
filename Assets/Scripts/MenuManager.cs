using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public MenuTransitionHandler CurrentMenu;

	public void Start()
	{
		ShowMenu(CurrentMenu);
	}

	public void ShowMenu(MenuTransitionHandler menu)
	{
		if (CurrentMenu != null)
			CurrentMenu.IsOpen = false;

		CurrentMenu = menu;
		CurrentMenu.IsOpen = true;
	}
}