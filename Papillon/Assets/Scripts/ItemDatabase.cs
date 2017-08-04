using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    private static List<Item> itemList;

    public static void init()
    {
        try
        {
            string line;
            string[] words;
            int itemCode = 0;

            StreamReader reader = new StreamReader("./Assets/Resources/Data/Item.txt", Encoding.Default);

            using (reader)
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    itemCode++;
                    words = line.Split(' ');
                    if (words.Length == 4)
                        itemList.Add(new Item(itemCode,
                            words[0].Replace('_',' '),
                            words[1].Replace('_', ' '),
                            System.Convert.ToSingle(words[2]),
                            System.Convert.ToInt32(words[3])));
                    else
                    {
                        //TODO : ITEM EFFECT
                    }
                    line = reader.ReadLine();
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("Wrong File" + e);
        }
    }

    public static Item findItem(int id) {
        foreach(Item item in itemList)
            if(item.getId() == id)
                return item;
        return new Item(0, "notExists", "", 0.0f, ITEMTYPE.MATERIAL, null);
    }
}
