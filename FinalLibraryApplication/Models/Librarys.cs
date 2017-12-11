using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalLibraryApplication
{
    [XmlRoot("Librarys")]
    public class Librarys
    {
        [XmlElement("Library")]
        public List<Library> librarys = new List<Library>();
    }
}

