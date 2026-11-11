using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace _20261111_SerializationDemo
{
    [Serializable]
    public struct Student
    {
        [XmlAttribute]
        public int RBN { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        //[XmlIgnore]
        public double AvgMark { get; set; }

        public override string ToString()
        {
            return $"{RBN} - {Name}, {AvgMark}";
        }
    }
}
