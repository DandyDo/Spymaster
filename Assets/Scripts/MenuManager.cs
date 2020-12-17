using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Menu[] menus;

    public static MenuManager Instance; // Singleton

    private void Awake()
    {
        Instance = this;
    }

    // Open menu by using its string name  (good for calling through unrelated GameObjects). THIS SCRIPT CLOSES OTHER MENUS AND LEAVES THE WANTED MENU OPEN
    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                menus[i].Open();
            }
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    // Open menu by using its type. THIS SCRIPT CLOSES OTHER MENUS AND LEAVES THE WANTED MENU OPEN
    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }
    
    // Open and close the same menu only (Toggle Mode). THIS IS WHAT YOU WANT.
    public void ToggleMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menu.menuName)
            { 
                if (menus[i].open)
                {
                    menus[i].Close();

                }
                else if (!menus[i].open)
                {
                    menus[i].Open();
                }
            }
        }
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }
}
