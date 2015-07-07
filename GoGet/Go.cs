/*
 * GoGet v1.0
 * License: The MIT License (MIT)
 * Code: https://github.com/jdemeuse1204/GoGet
 * Email: james.demeuse@gmail.com
 * Copyright (c) 2015 James Demeuse
 */

using System.Linq;
using System.Reflection;

namespace GoGet
{
    /// <summary>
    /// Travels down the specified path of the object provided to grab the value of the 
    /// child object
    /// </summary>
    public static class Go
    {
        #region Property
        /// <summary>
        /// Traverses the specified path to find the specified property and grab its value.  Will seach both properties and fields on its way to find the final property value
        /// </summary>
        /// <param name="o">any object with properties/fields/methods</param>
        /// <param name="path">Path to object</param>
        /// <returns>T</returns>
        public static T GetPropertyValue<T>(object o, string path)
        {
            var info = GetProperty(o, path);

            return GetPropertyValue<T>(info);
        }

        /// <summary>
        /// Uses a previous get info to find the properties value.
        /// </summary>
        /// <typeparam name="T">Result</typeparam>
        /// <param name="info">Get Info</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(GetInfo info)
        {
            return info == null
                ? default(T)
                : info.Info is PropertyInfo ? (T)((PropertyInfo)info.Info).GetValue(info.FoundObject) : default(T);
        }

        /// <summary>
        /// Traverses the specified path to find the specified property.  Will seach both properties and fields on its way to find the final property
        /// </summary>
        /// <param name="o">any object with properties/fields/methods</param>
        /// <param name="path">Path to object</param>
        /// <returns>T</returns>
        public static GetInfo GetProperty(object o, string path)
        {
            var get = Get(o, path);

            return GetProperty(get);
        }

        /// <summary>
        /// Traverses the specified path to find the specified property.  Will seach both properties and fields on its way to find the final property
        /// </summary>
        /// <param name="get">Get from any previous search</param>
        /// <returns>PropertyInfo</returns>
        public static GetInfo GetProperty(Get get)
        {
            return get == null ? null : new GetInfo(get, get.FoundObject.GetType().GetProperty(get.NavigationPathLast));
        }
        #endregion

        #region Field
        /// <summary>
        /// Traverses the specified path to find the specified field.  Will seach both properties and fields on its way to find the field
        /// </summary>
        /// <param name="o">any object with properties/fields/methods</param>
        /// <param name="path">Path to object</param>
        /// <returns>T</returns>
        public static GetInfo GetField(object o, string path)
        {
            var get = Get(o, path);

            return GetField(get);
        }

        /// <summary>
        /// Traverses the specified path to find the specified field.  Will seach both properties and fields on its way to find the field
        /// </summary>
        /// <param name="get">Get from any previous search</param>
        /// <returns>PropertyInfo</returns>
        public static GetInfo GetField(Get get)
        {
            return get == null ? null : new GetInfo(get, get.FoundObject.GetType().GetField(get.NavigationPathLast));
        }

        /// <summary>
        /// Traverses the specified path to find the specified field and grab its value.  Will seach both properties and fields on its way to find the final field value
        /// </summary>
        /// <param name="o">any object with properties/fields/methods</param>
        /// <param name="path">Path to object</param>
        /// <returns>T</returns>
        public static T GetFieldValue<T>(object o, string path)
        {
            var info = GetField(o, path);

            return GetFieldValue<T>(info);
        }

        public static T GetFieldValue<T>(GetInfo info)
        {
            return info == null
                ? default(T)
                : info.Info is FieldInfo ? (T)((FieldInfo)info.Info).GetValue(info.FoundObject) : default(T);
        }
        #endregion

        #region Method
        /// <summary>
        /// Traverses the specified path to find the specified method.  Will seach both properties and fields on its way to find the final method
        /// </summary>
        /// <param name="o">any object with properties/fields/methods</param>
        /// <param name="path">Path to object</param>
        /// <returns>T</returns>
        public static MethodInfo GetMethod(object o, string path)
        {
            var get = Get(o, path);

            return GetMethod(get);
        }

        /// <summary>
        /// Traverses the specified path to find the specified method.  Will seach both properties and fields on its way to find the final method
        /// </summary>
        /// <param name="get">Get from any previous search</param>
        /// <returns>PropertyInfo</returns>
        public static MethodInfo GetMethod(Get get)
        {
            return get == null ? null : get.FoundObject.GetType().GetMethod(get.NavigationPathLast);
        }
        #endregion

        /// <summary>
        /// Traverses the specified path to find the base class where the property/field/method resides.
        /// </summary>
        /// <param name="o">any object with properties/fields/methods</param>
        /// <param name="path">Path to object</param>
        /// <returns>Get</returns>
        public static Get Get(object o, string path)
        {
            var navigationStack = path.Split('.');
            var currentObject = o;

            // do not travel over the last item in the stack, that is our value
            for (var i = 0; i < navigationStack.Count() - 1; i++)
            {
                var stackItem = navigationStack[i];
                var foundProperty = currentObject.GetType().GetProperty(stackItem);
                var foundField = currentObject.GetType().GetField(stackItem);

                currentObject = foundProperty != null
                    ? foundProperty.GetValue(currentObject)
                    : foundField != null ? foundField.GetValue(currentObject) : null;

                // if the object is null return default
                if (currentObject == null) return null;
            }

            return new Get(navigationStack.Last(), currentObject);
        }
    }
}
