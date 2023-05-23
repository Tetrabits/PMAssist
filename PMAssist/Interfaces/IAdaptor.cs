namespace PMAssist.Interfaces
{
    public interface IAdaptor<T,U> where T: class where U:class 
    {
        U Adapt(T input);
    }
}
