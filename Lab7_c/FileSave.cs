using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;

namespace Lab7_c
{
    public class FileManager
    {
        public static void SerializationJSON(Bibliotek bibliotek, string fileName)
        {
            if (bibliotek is not null && fileName.EndsWith(".json"))
            {
                string output = JsonSerializer.Serialize(bibliotek);
                using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(output);
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }


        public static Bibliotek DeserializationJSON(string fileName)
        {
            if (fileName.EndsWith(".json"))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string json = reader.ReadToEnd();
                        Bibliotek bibliotek = JsonSerializer.Deserialize<Bibliotek>(json);
                        return bibliotek;
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }


        public static void SerializationBinary(Bibliotek bibliotek, string fileName)
        {
            if (bibliotek is not null && fileName.EndsWith(".bin"))
            {
                using (FileStream fileStream = new(fileName, FileMode.OpenOrCreate))
                {
                    using (BinaryWriter writer = new(fileStream, Encoding.Default))
                    {
                        foreach (Buch buch in bibliotek.BucherDict.Values)
                        {
                            writer.Write(buch.Name);
                            writer.Write(buch.Author);
                            writer.Write(buch.Pages);
                            writer.Write(buch.Id);
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Invalid arguments for binary serialization");
            }
        }
        public static Bibliotek DeserializationBinary(string fileName)
        {
            if (fileName.EndsWith(".bin"))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        Bibliotek tempStorehouse = new Bibliotek();
                        while (reader.BaseStream.Position < reader.BaseStream.Length)
                        {
                            Buch buch = new Buch(reader.ReadString(), reader.ReadString(), reader.ReadInt32(), reader.ReadInt32());
                            tempStorehouse.AddBuch(buch);
                        }
                        return tempStorehouse;
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }
    }
}