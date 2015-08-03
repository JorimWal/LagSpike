using System.Collections.Generic;
//I AM ROOT
public class Root
{
    protected Dictionary<string, GameObjectList> rootDictionary;

    public Root()
    {
        rootDictionary = new Dictionary<string, GameObjectList>();
    }

    public void AddObject(GameObject obj)
    {
        if (rootDictionary.ContainsKey(obj.Type))
            rootDictionary[obj.Type].Add(obj);
        else
        {
            switch(obj.Type)
            {
                default :
                    rootDictionary[obj.Type] = new GameObjectList();
                    rootDictionary[obj.Type].Add(obj);
                    break;
            }
        }
    }

    public GameObject Find(string TypeID)
    {
        string type = TypeID.Split()[0];
        int id = int.Parse(TypeID.Split()[1]);
        if (this.GetList(type) == null)
            return null;
        else
        {
            return this.GetList(type).Find(id);
        }
    }

    public GameObjectList GetList(string type)
    {
        if (rootDictionary.ContainsKey(type))
            return rootDictionary[type];
        else
            return null;
    }
}