using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCM.Core.Utils
{
    public class EnumHelp
    {
        public static IList<T> EnumToList<T>()
        {
            if (!typeof(T).IsEnum)
                throw new Exception("T isn't an enumerated type");

            IList<T> list = new List<T>();
            Type type = typeof(T);
            if (type != null)
            {
                Array enumValues = Enum.GetValues(type);
                foreach (T value in enumValues)
                {
                    list.Add(value);
                }
            }

            return list;
        }
    }
}
