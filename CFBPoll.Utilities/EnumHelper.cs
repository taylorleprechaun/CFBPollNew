using System.ComponentModel;
using System.Reflection;

namespace CFBPoll.Utilities
{
    public static class EnumHelper
    {
        /// <summary>
        /// Get the string descriptor for a given enum.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="enumerationValue">The enum value.</param>
        /// <returns>The string descriptor for the given enum.</returns>
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }
    }
}
