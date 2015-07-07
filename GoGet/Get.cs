namespace GoGet
{
    public class Get
    {
        public Get(string navigationPathLast, object foundObject)
        {
            NavigationPathLast = navigationPathLast;
            FoundObject = foundObject;
        }

        public readonly string NavigationPathLast;

        public readonly object FoundObject;
    }
}
