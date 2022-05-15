using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrecaoBanco
{
    [Serializable]
    public class PixException : Exception
    {
        public PixException() { }
        public PixException(string message) : base(message) { }
        public PixException(string message, Exception inner) : base(message, inner) { }
        protected PixException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
