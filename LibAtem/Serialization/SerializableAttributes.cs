﻿using System;
using System.Reflection;

namespace LibAtem.Serialization
{
    public class NonSerializedAttribute : Attribute
    {
    }

    public class SerializableAttribute : Attribute
    {
        public uint StartByte { get; }

        public SerializableAttribute(uint startByte)
        {
            StartByte = startByte;
        }
    }

    public abstract class SerializableAttributeBase : Attribute
    {
        public abstract void Serialize(byte[] data, uint start, object val);
        public abstract object Deserialize(byte[] data, uint start, PropertyInfo prop);
        public abstract bool AreEqual(object val1, object val2);
    }

    public interface IRandomGeneratorAttribute
    {
        object GetRandom(Random random);
        bool IsValid(object obj);
    }
}