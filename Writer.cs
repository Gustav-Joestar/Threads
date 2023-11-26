using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    internal class Writers
    {
        StreamWriter? _writer;
        private string _path;

        public Writers(string path)
        {
            _path = path;
        }

        public void writeLineInFile(string data, bool shouldAdd = false)
        {
            _writer = new StreamWriter(_path, shouldAdd);
            _writer.WriteLine(data);
            _writer.Close();
            _writer.Dispose();
        }
    }
}