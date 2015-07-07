/*
 * GoGet v1.0
 * License: The MIT License (MIT)
 * Code: https://github.com/jdemeuse1204/GoGet
 * Email: james.demeuse@gmail.com
 * Copyright (c) 2015 James Demeuse
 */

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
