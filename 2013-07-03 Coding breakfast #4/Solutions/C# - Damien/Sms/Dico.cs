using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace Sms
{
    public interface IDico
    {
        StringCollection this[string seed] { get; }
        void Add(string seed, string candidate);
    }

    public class Dico: IDico
    {
        private readonly Hashtable _list = new Hashtable();

        public StringCollection this[string seed]
        {
            get
            {
                if (string.IsNullOrEmpty(seed))
                    throw new ArgumentNullException("seed");
                if (!_list.ContainsKey(seed))
                    return new StringCollection{seed};
                return ((StringCollection)_list[seed]);
            }
        }

        public void Add(string seed, string candidate)
        {
            if(string.IsNullOrEmpty(seed))
                throw new ArgumentNullException("seed");
            if (string.IsNullOrEmpty(candidate))
                throw new ArgumentNullException("candidate");
            if(_list.Contains(seed))
            {
                var values = _list[seed] as StringCollection;
                if (!values.Contains(candidate))
                    values.Add(candidate);
            }
            else
                _list.Add(seed, new StringCollection{candidate});
        }

        public delegate string SeedCalculator(string original);

        public void LoadFromStream(Stream stream, SeedCalculator calculator)
        {
            using(var reader = new StreamReader(stream, true))
            {
                while (!reader.EndOfStream)
                {
                    var value = reader.ReadLine();
                    Add(calculator(value), value);
                }
            }
        }

        public void LoadFromFile(string filename, SeedCalculator calculator)
        {
            using (var file = File.OpenRead(filename))
            {
                LoadFromStream(file, calculator);
            }
        }
    }
}
