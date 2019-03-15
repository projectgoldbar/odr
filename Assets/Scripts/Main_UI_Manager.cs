using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_UI_Manager : MonoBehaviour
{
    public GameObject shopPanel;
    public Text goldText;

    private void Awake()
    {
        goldText.text = "gold" + ItemGoldDataBase.instance.gold;
    }

    public void GameStart()
    {
        SceneManager.LoadScene("game");
    }

    public void TestScene()
    {
        SceneManager.LoadScene("PT_Test");
    }

    public void ShopOpen()
    {
        shopPanel.SetActive(true);
    }

    public void ShopClose()
    {
        shopPanel.SetActive(false);
    }

    public void Buy(int index)
    {
        ItemGoldDataBase.instance.SpwanItemDataList.Add(ItemGoldDataBase.instance.AllitemList[index]);
        ItemGoldDataBase.instance.gold -= ItemGoldDataBase.instance.AllitemList[index].GetComponent<Item>().price;

        goldText.text = "gold" + ItemGoldDataBase.instance.gold;
    }
}