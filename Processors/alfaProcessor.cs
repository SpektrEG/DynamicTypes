using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors
{
    class alfaProcessor
    {
        int field;
        public int Field
        {
            get { return field; }
            set { field = value; }
        }

        public alfaProcessor(int key)
        {
            this.field = key;
        }
        public alfaProcessor(alfaProcessor key)
        {
            this.field = key.field;
        }

        public static alfaProcessor operator + (alfaProcessor a1, alfaProcessor a2)
        {
            return new alfaProcessor(a1.Field + a2.Field);
        }

        public override string ToString()
        {
            return String.Format("This is alfaProcessor object. Field: {0}", field);
        }
    }
}
