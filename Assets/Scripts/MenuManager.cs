using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Menu[] menus;

    public static MenuManager Instance; // Singleton

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu (string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName && !menus[i].open)
            {
                Debug.Log("Open menu called");
                menus[i].Open();
            }
            else if (menus[i].menuName == menuName && menus[i].open)
            {
                Debug.Log("Close menu called");
                menus[i].Close();
            }
        }
    }
 
    public void OpenMenu (Menu menu)
    {
        if (menu.open)
        {
            Debug.Log("Close menu called");
            menu.Close();
        }
        else if (!menu.open)
        {
            Debug.Log("Open menu called");
            menu.Open();
        }
        
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }
}
