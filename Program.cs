using System.Text.Json;
using System.Xml.Serialization;

namespace _20261111_SerializationDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 1, 2, 3, 4, 5 };

            List<Student> group1 = new List<Student>
                {
                    new Student { RBN = 1, Name = "Ivan", AvgMark = 4.5 },
                    new Student { RBN = 2, Name = "Petar", AvgMark = 3.8 },
                    new Student { RBN = 3, Name = "Georgi", AvgMark = 5.0 }
                };

            #region ---==  xml  ==---

            {
                XmlSerializer frmtrXmlArrInts = new XmlSerializer(typeof(int[]));

                using (FileStream fs = new FileStream("data.xml", FileMode.Create, FileAccess.Write))
                {
                    frmtrXmlArrInts.Serialize(fs, data);
                }

                using (FileStream fs = new FileStream("data.xml", FileMode.Open, FileAccess.Read))
                {
                    int[] dataCopy = (int[])frmtrXmlArrInts.Deserialize(fs);

                    Console.WriteLine("dataCopy:");
                    for (int i = 0; i < dataCopy.Length; i++)
                    {
                        Console.Write($"{dataCopy[i]} ");
                    }
                    Console.WriteLine();
                }

                XmlSerializer frmtrXmlStudLst = new XmlSerializer(typeof(List<Student>));

                using (FileStream fs = new FileStream("group1.xml", FileMode.Create, FileAccess.Write))
                {
                    frmtrXmlStudLst.Serialize(fs, group1);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                using (FileStream fs = new FileStream("group1.xml", FileMode.Open, FileAccess.Read))
                {
                    List<Student> group1Copy = (List<Student>)frmtrXmlStudLst.Deserialize(fs);

                    Console.WriteLine("group1Copy:");
                    foreach (var student in group1Copy)
                    {
                        Console.WriteLine(student);
                    }
                }
            }


            #endregion

            #region json

            {
                Console.ForegroundColor = ConsoleColor.Red;

                using (FileStream fs = new FileStream("data.json", FileMode.Create, FileAccess.Write))
                {
                    JsonSerializer.Serialize(fs, data);
                }

                using (FileStream fs = new FileStream("data.json", FileMode.Open, FileAccess.Read))
                {
                    int[] dataCopy = (int[])JsonSerializer.Deserialize(fs, typeof(int[]));

                    Console.WriteLine("dataCopy:");
                    for (int i = 0; i < dataCopy.Length; i++)
                    {
                        Console.Write($"{dataCopy[i]} ");
                    }
                    Console.WriteLine();
                }

                XmlSerializer frmtrXmlStudLst = new XmlSerializer(typeof(List<Student>));

                using (FileStream fs = new FileStream("group1.json", FileMode.Create, FileAccess.Write))
                {
                    JsonSerializer.Serialize(fs, group1);
                }

                Console.ForegroundColor = ConsoleColor.White;
                using (FileStream fs = new FileStream("group1.json", FileMode.Open, FileAccess.Read))
                {
                    List<Student> group1Copy = (List<Student>)JsonSerializer.Deserialize(fs, typeof(List<Student>));

                    Console.WriteLine("group1Copy:");
                    foreach (var student in group1Copy)
                    {
                        Console.WriteLine(student);
                    }
                }
            }

            #endregion
        }
    }
}
