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
        if (this.GetList(obj.Type) != null)
            this.GetList(obj.Type).Add(obj);
        else
        {
            rootDictionary[obj.Type] = new GameObjectList();
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