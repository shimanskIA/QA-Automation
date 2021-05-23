using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Interfaces
{
    public interface ISerializable<T> where T: class
    {
        public void Serialize();
        public List<T> Deserealize();
    }
}
