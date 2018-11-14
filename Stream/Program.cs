using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace Stream
{
    class Program
    {
        private static FileStream _fileStream;
        private static StreamWriter _streamWriter;
        private static StreamReader _streamReader;
        private static string _path = @"C://Store";
        static void Main(string[] args)
        {
           
           
            // Write data into File
             WriteDataIntoFile();

            // Read data from File
            ReadDataFromFile();

            // Write Bytes data into File
            WriteByteDatIntoFile();

            // Read Bytes data From File
            ReadByteDatFromFile();

            // Serialization
            Serialization();

            // Deserialization
            Deserialization();

            Console.WriteLine("Press Enter to end the program");
            Console.ReadKey();


        }
        static void WriteDataIntoFile()
        {
            try
            {
                // Call check path is Exist or not method
                CheckPathIsExist();
                // File stream : Writing and Reading data stream
                 _fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write);
                _streamWriter = new StreamWriter(_fileStream);
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("data is inserting now:........" + i);
                    _streamWriter.WriteLine("The number of message is 100 :" + i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Create directory and folder 
                CreateDirectoryOrFolder();
            }
            finally
            {
                _streamWriter?.Close();
                _fileStream?.Close();
            }
        }

        static void ReadDataFromFile()
        {
            try
            {
                // FileStream
                _fileStream = new FileStream(_path, FileMode.Open);
                // streamReader
                _streamReader = new StreamReader(_fileStream);

                while (!_streamReader.EndOfStream)
                {
                    Console.WriteLine(_streamReader.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _streamReader?.Close();
                _fileStream?.Close();
            }
           
        }
        static void WriteByteDatIntoFile()
        {
            try
            {
                // File stream : Writing and Reading data stream
                _fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write);
                for (int i = 0; i < 100; i++)
                {
                   _fileStream.WriteByte((byte)i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _fileStream?.Close();
            }
        }
        static void ReadByteDatFromFile()
        {
            try
            {
                // File stream : Writing and Reading data stream
                _fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read);
                for (int i = 0; i < 100; i++)
                {
                    var data = _fileStream.ReadByte();
                    Console.WriteLine(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _fileStream?.Close();
            }
        }


        // Check Path is Exist or not 
        static void CheckPathIsExist()
        {
            if (!Directory.Exists(_path))
            {
                throw new Exception("first time you need to Create directory Path ");
            }
            else
            {
                _path = @"C://Store/data";
            }
        }

        // simply Create Directory and folder
        static void CreateDirectoryOrFolder()
        {
            Directory.CreateDirectory(_path);
            string fileName = "data.txt";
            _path = _path + "/" + fileName;
            File.Create(_path);
            Console.WriteLine(".........................................................");
            Console.WriteLine("Now Path is Created in your current directory:" + _path);
            Console.WriteLine("Run Program again");
        }

        // Serialization : mean Convert object into Byte of streams
        static void Serialization()
        {
            List<Lizard> listLizard = new List<Lizard>()
            {
                new Lizard("BlueLizard" , "1", true),
                new Lizard("GreenLizard" , "2", false),
                new Lizard("BlackLizard" , "3", true)
            };

            try
            {
                // open the file for writing the data into file 
                _fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write);

                // BinaryFormatter class : convert object into byte of stream
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(_fileStream, listLizard);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _fileStream?.Close();
            }
        }
        static void Deserialization()
        {
            
            try
            {
                // open the file for writing the data into file 
                _fileStream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Read);

                // BinaryFormatter class : convert object into byte of stream
                BinaryFormatter bf = new BinaryFormatter();
                // Deserialize means : 
               List<Lizard> lizard =  bf.Deserialize(_fileStream) as List<Lizard>;

                if (lizard != null)
                    foreach (var lizzy in lizard)
                    {
                        Console.WriteLine("Type:{0}- Number:{1}- Health:{2}", lizzy.Type, lizzy.Number, lizzy.Healthy);
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                _fileStream?.Close();
            }
        }
    }
}
