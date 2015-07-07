using System.Reflection;


namespace GoGet
{
    public class GetInfo : Get
    {
        public readonly MemberInfo Info;

        public GetInfo(string navigationPathLast, object foundObject, MemberInfo info) 
            : base(navigationPathLast, foundObject)
        {
            Info = info;
        }

        public GetInfo(Get get, MemberInfo info)
            : base(get.NavigationPathLast, get.FoundObject)
        {
            Info = info;
        }
    }
}
