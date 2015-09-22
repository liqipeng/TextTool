using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TextTool.Common
{
    public static class Serializer
    {
        public static void SerializeToBinary<T>(T obj,Stream writableStream) 
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(writableStream, obj);
        }

        public static T DeserializeFromBinary<T>(Stream stream)
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            Object obj = bFormatter.Deserialize(stream);

            return (T)obj;
        }
    }
}
