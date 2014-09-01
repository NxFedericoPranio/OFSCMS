using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DataClasses.OFS.Serialization
{
    internal class Serializator
    {
        internal void SerializeObject(string fileName, object objectToSerialize)
        {
            XmlWriter writer = null;
            try
            {
                
                XmlSerializer serializer =
                new XmlSerializer(objectToSerialize.GetType());

                // Create an XmlTextWriter using a FileStream.
                FileMode fileMode = FileMode.CreateNew;

                if (File.Exists(fileName))
                {
                    fileMode = FileMode.Truncate;
                }

                Stream fs = new FileStream(fileName, fileMode);
                writer =
                new XmlTextWriter(fs, Encoding.Unicode);
                // Serialize using the XmlTextWriter.
                serializer.Serialize(writer, objectToSerialize);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                writer.Close();
            }
        }

        internal object DeserializeObject(string fileName, Type type)
        {
            FileStream fs = null;
            try
            {
                // Create an instance of the XmlSerializer specifying type and namespace.
                XmlSerializer serializer = new
                XmlSerializer(type);

                // A FileStream is needed to read the XML document.
                fs = new FileStream(fileName, FileMode.Open);
                XmlReader reader = XmlReader.Create(fs);

                // Declare an object variable of the type to be deserialized.
                object i;

                // Use the Deserialize method to restore the object's state.
                i = serializer.Deserialize(reader);
                return i;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (!(fs == null))
                    fs.Close();
            }
        }
    }
}
