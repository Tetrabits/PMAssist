using PMAssist.Interfaces;

namespace PMAssist.Adaptors
{
    public class ActivityAdaptor<T, U> : IAdaptor<T, U> where T : class where U : class
    {
        public U Adapt(T input)
        {
            throw new NotImplementedException();
        }
    }
}
