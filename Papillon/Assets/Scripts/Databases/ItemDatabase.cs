using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    private static List<Item> itemList;

    public static void init(TextAsset reader)
    {
        itemList = new List<Item>();

        try
        {
            string[] lines;
            string[] words;
            
            lines = reader.text.Split('\n');
            foreach(string line in lines)
            {
                // for database comment
                if(line[0] == '#')
                    continue;
                    
                words = line.TrimEnd(' ').Split(' ');
                if (words.Length == 5) {
                    // ITEM DB : 'ID NAME DESCRIPTION WEIGHT TYPE'
                    itemList.Add(new Item(
                        int.Parse(words[0]),
                        words[1].Replace('_', ' '),
                        words[2].Replace('_', ' '),
                        float.Parse(words[3]),
                        int.Parse(words[4])
                        ));
                } else if(words.Length > 5){
                    // ITEM DB : 'ID NAME DESCRIPTION WEIGHT TYPE EFFECT_NAME EFFECT_PARAMETERS'

                    List<int> effect_param = new List<int>();
                    for(int i = 6; i < words.Length; i++)
                        effect_param.Add(int.Parse(words[i]));
                    ItemEffect effect = new ItemEffect(words[5], effect_param);

                    itemList.Add(new Item(
                        int.Parse(words[0]),
                        words[1].Replace('_', ' '),
                        words[2].Replace('_', ' '),
                        float.Parse(words[3]),
                        int.Parse(words[4]),
                        effect
                        ));
                } else {
                    Debug.Log("ERROR : wrong item format");
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

    public static int findIdByName(string name) {
        foreach (Item item in itemList)
            if (item.getName() == name)
                return item.getId();
        return -1;
    }

    public static string findNameById(int id) {
        foreach (Item item in itemList)
            if (item.getId() == id)
                return item.getName();
        return "notExists";
    }
}
