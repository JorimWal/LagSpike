
public class IDTracker
{
    int idcounter;
    public IDTracker()
    {
        idcounter = 5000;
    }

    public int GetKey()
    {
        idcounter++;
        return idcounter - 1;
    }

    public void DeleteKey()
    {

    }
}

