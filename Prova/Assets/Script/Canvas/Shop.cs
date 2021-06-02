using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    List<Item> listItem;
    void Start()
    {
        

        //PlayerPrefs.SetInt("money", 400);
        string shopJson= PlayerPrefs.GetString("shopItem","");
        Item[] shopItem;
        if(shopJson==""){
            print("son nella stringa ");
            shopItem= new Item[2];
            shopItem[0]=new Item{name="life",descriptions="Aggiunge un cuore", price=100, remains=8};
            shopItem[1]=new Item{name="double",descriptions="Raddoppia le monete nella prossima partita", price=400, remains=int.MaxValue};
            
            string json=JsonHelper.ToJson<Item>(shopItem);
            PlayerPrefs.SetString("shopItem", json);
        }
        else {
            print("prendo l'oggetto");
            shopItem= JsonHelper.FromJson<Item>(shopJson);           
            
        }
        int i=1;
        foreach(Item x in shopItem){
                GameObject.Find("buytxt"+i).GetComponent<TMPro.TextMeshProUGUI>().text=""+x.price;
                GameObject.Find("Description"+i).GetComponent<TMPro.TextMeshProUGUI>().text=x.descriptions;
                if(x.name=="life") GameObject.Find("howMany"+i).GetComponent<TMPro.TextMeshProUGUI>().text="Rimangono "+x.remains+" cuori da poter comprare";
                else GameObject.Find("howMany"+i).GetComponent<TMPro.TextMeshProUGUI>().text="infiniti acquisti";
                Button button=GameObject.Find("Buy"+i).GetComponent<Button>();
                if(x.price>PlayerPrefs.GetInt("money"))
                    button.interactable=false;
                if(x.name=="life" && x.remains==0)
                    button.interactable=false;
                if(x.name=="double" && GameManager.getInstance().GetBoost())
                    button.interactable=false;
                button.onClick.AddListener(() => { 
                        int money=PlayerPrefs.GetInt("money"); 
                        money-=x.price;
                        PlayerPrefs.SetInt("money",money); 
                        print(money);
                        if(x.name=="life"){
                            x.remains--;
                            int life=PlayerPrefs.GetInt("PlayerMaxLife",4);
                            PlayerPrefs.SetInt("PlayerMaxLife",life+2);
                        }
                        else{
                            GameManager.getInstance().SetBoost();
                            button.interactable=false;
                        }
                        string json2=JsonHelper.ToJson<Item>(shopItem);
                        PlayerPrefs.SetString("shopItem", json2); 
                        /*if(money<=x.price)
                            button.interactable=false;  */
                        Scene scene = SceneManager.GetActiveScene(); 
                        SceneManager.LoadScene(scene.name);
                                                
                });
                i++;
        }

        string json1=JsonHelper.ToJson<Item>(shopItem);
        PlayerPrefs.SetString("shopItem", json1);  
    
    }


    [System.Serializable]
    private class Item{
        public string name;
        public string descriptions;
        public int price;
        public int remains;
        //public Image image;
    }
}
