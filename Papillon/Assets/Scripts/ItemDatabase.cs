using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    private static List<Item> itemList;

    public static void init()
    {
        itemList = new List<Item>();

        try
        {
            string line;
            string[] words;

            StreamReader reader = new StreamReader("./Assets/Resources/Data/Item.txt", Encoding.Default);

            using (reader)
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    words = line.Split(' ');
                    if (words.Length == 5)
                        // ITEM DB : 'ID NAME DESCRIPTION WEIGHT TYPE'
                        itemList.Add(new Item(
                            int.Parse(words[0]),
                            words[1].Replace('_',' '),
                            words[2].Replace('_', ' '),
                            float.Parse(words[3]),
                            int.Parse(words[4])
                            ));
                    else
                    {
                        //TODO : ITEM EFFECT
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
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
