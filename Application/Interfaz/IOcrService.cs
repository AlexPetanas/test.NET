using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaz
{
    public interface IOcrService
    {
        public Task<string> GetTextString(MemoryStream File);
    }
}
