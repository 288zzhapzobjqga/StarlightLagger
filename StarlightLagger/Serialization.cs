﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Il2CppSystem;
using Il2CppSystem.IO;
using Il2CppSystem.Runtime.Serialization.Formatters.Binary;

namespace StarlightLagger
{
    internal static class Serialization
    {
        public static byte[] ToByteArray(Il2CppSystem.Object obj)
        {
            if (obj == null) return null;
            var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var ms = new Il2CppSystem.IO.MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static byte[] ToByteArray(object obj)
        {
            if (obj == null) return null;
            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var ms = new System.IO.MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null) return default(T);
            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (var ms = new System.IO.MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }

        public static T IL2CPPFromByteArray<T>(byte[] data)
        {
            if (data == null) return default(T);
            var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var ms = new Il2CppSystem.IO.MemoryStream(data);
            object obj = bf.Deserialize(ms);
            return (T)obj;
        }
        public static T FromIL2CPPToManaged<T>(Il2CppSystem.Object obj)
        {
            return FromByteArray<T>(ToByteArray(obj));
        }

        public static T FromManagedToIL2CPP<T>(object obj)
        {
            return IL2CPPFromByteArray<T>(ToByteArray(obj));
        }
    }
}
