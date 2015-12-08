using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors
{
    public class betaProcessor
    {
        int field;
        public int Field
        {
            get { return field; }
            set { field = value; }
        }

        public betaProcessor(int key)
        {
            this.field = key;
        }
        public betaProcessor(betaProcessor key)
        {
            this.field = key.field;
        }

        public static betaProcessor operator + (betaProcessor b1, betaProcessor b2)
        {
            return new betaProcessor(b1.field + b2.field);
        }

        public override string ToString()
        {
            return String.Format("This is betaProcessor object. Field: {0}", field);
        }
    }
}
